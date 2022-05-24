using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public int maxHealth = 3;
    int currentHealth;
    public float speed;
    private Rigidbody2D body;
    private float horizontal;
    public float jump;
    public bool isJumping;
    Animator animator; 
    Vector2 lookDirection = new Vector2(1, 0);
    bool isInvincible;
    float invincibleTimer;
    public float timeInvincible = 2.0f;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

    }
    // Update is called once per frame
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        
        Vector2 move = new Vector2(horizontal, body.velocity.y);
        if(Input.GetKeyDown(KeyCode.UpArrow) && !isJumping )
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
        

        
        

    }
    void FixedUpdate()                
    {
        Vector2 position = body.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
       
        body.MovePosition(position);

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            Debug.Log("collide");
        }
    }
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            isInvincible = true;
            invincibleTimer = timeInvincible;
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            Debug.Log(currentHealth + "/" + maxHealth);
            //UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);

        }

        //currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
       // UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }
}
