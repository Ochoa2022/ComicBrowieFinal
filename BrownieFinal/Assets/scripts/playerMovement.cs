using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal")* speed, body.velocity.y);
    }
}
