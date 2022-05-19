using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    private float horizontal;
    private float vertical;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);


    }
    void FixedUpdate()                
    {
        Vector2 position = body.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        body.MovePosition(position);

    }
}
