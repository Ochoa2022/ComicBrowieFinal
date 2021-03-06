using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude > 1000.0f ) // destorys game object once it reaches a certain point
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force) // shoots bullet
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Dead(); // sets off the dead function for alien
        } 
        Debug.Log("Projectile Collision with" + other.gameObject);
        Destroy(gameObject);
    }
}
