using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerMovement : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public float speed;
    private Rigidbody2D body;
    private float horizontal;
    public float jump;
    public bool isJumping;
    Animator animator;
    AudioSource audioSource;
    Vector2 lookDirection = new Vector2(1, 0);
    
    float invincibleTimer;
    public float timeInvincible = 2.0f;
    public GameObject projectilePrefab;
    public AudioClip shootSound;
    public AudioClip HurtSound;
    public GameObject gameOver;
    
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
        

    }
    // Update is called once per frame
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        
        Vector2 move = new Vector2(horizontal, body.velocity.y); // moves player left and right
        if(Input.GetKeyDown(KeyCode.UpArrow) && !isJumping ) // lets player jump if on ground
        {
            body.AddForce(new Vector2(body.velocity.x, jump));
            isJumping = true;
            animator.SetTrigger("Jump");
        }


        if (!Mathf.Approximately(move.x, 0.0f)) 
        {
            lookDirection.Set(move.x, 0);
            lookDirection.Normalize();
        }
        
            animator.SetFloat("Move X", lookDirection.x);
            animator.SetFloat("Speed", move.magnitude);
        if (Input.GetKeyDown("space")) // sets off projectiles
        {
            Shoot();
            audioSource.PlayOneShot(shootSound);

        }




    }
    void FixedUpdate()                
    {
        Vector2 position = body.position;
        position.x = position.x + speed * horizontal * Time.deltaTime; // moves player according to speed
       
        body.MovePosition(position);

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) //makes sure player is on the ground when jumping
        {
            isJumping = false;
            Debug.Log("collide");
        }
        if (other.gameObject.CompareTag("Finish")) // to check if player has touched invisible collider when they fall that finish their game because they lose
        {
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ChangeHealth(int amount) // chane the health when attacked
    {
        if (amount < 0)
        {
           
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            Debug.Log(currentHealth + "/" + maxHealth);
            animator.SetTrigger("Hurt");
            audioSource.PlayOneShot(HurtSound);


        }


    }
    void Shoot() // shoots projectile 
    {
        GameObject projectileObject = Instantiate(projectilePrefab, body.position + Vector2.up * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Shoot");
    }
   
}
