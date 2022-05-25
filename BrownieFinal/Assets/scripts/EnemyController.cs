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
    bool Alive = true;
    
    Animator animator;
    AudioSource audioSource;
    public AudioClip DeathSound;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();


    }
    void Update()
    { if(!Alive)
        {
            return;
        }
        timer -= Time.deltaTime;

        if (timer <0)
        {
            direction = -direction;
                timer = changeTime;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Alive)
        {
            return;
        }
        Vector2 position = rigidbody2D.position;
         position.x = position.x + Time.deltaTime * speed * direction; 

            rigidbody2D.MovePosition(position);
            animator.SetFloat("Move X", direction);
            
        

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        playerMovement player = other.gameObject.GetComponent<playerMovement>();
        if(player != null)
        {
            player.ChangeHealth(-1);
            animator.SetTrigger("attack");
        }
    }
    public void Dead()
    {
        Alive = false;
       
        rigidbody2D.simulated = false;
        animator.SetTrigger("Hurt");
        audioSource.PlayOneShot(DeathSound);
        //Instantiate(hitEffect, rigidbody2D.position + Vector2.up * 1.5f, Quaternion.identity);


    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
