using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;

    
    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    
    Animator animator;
    AudioSource audioSource;
    public AudioClip DeathSound;
    public AudioClip attackSound;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();


    }
    void Update()
    { 
        timer -= Time.deltaTime;

        if (timer <0)
        {
            direction = -direction;
                timer = changeTime;
        } // the amount of time before the alien switches directions 
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       
        Vector2 position = rigidbody2D.position;
         position.x = position.x + Time.deltaTime * speed * direction; 

            rigidbody2D.MovePosition(position);
            animator.SetFloat("Move X", direction);
            
        // moving aliens 

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        playerMovement player = other.gameObject.GetComponent<playerMovement>();
        if(player != null)
        {
            player.ChangeHealth(-1);
            animator.SetTrigger("attack");
            audioSource.PlayOneShot(attackSound);
            //alien attacking player

        }
    }
    public void Dead()
    {
        
       
        rigidbody2D.simulated = false;
        animator.SetTrigger("Hurt");
        audioSource.PlayOneShot(DeathSound);
        Invoke("Destroy", 1f);
        //alien death
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
