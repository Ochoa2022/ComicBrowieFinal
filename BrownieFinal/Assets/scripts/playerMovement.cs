using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    private float horizontal;
    public float jump;
    public bool isJumping;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
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
        }


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
}
