using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_walker : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    public float speed;
    public bool isFacingRight;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        if (!rb)
        {
            Debug.LogWarning("No Rigidbody 2D found...");
        }
        if (!sr)
        {
            Debug.LogWarning("No SpriteRenderer found...");
        }
            if (speed <= 0)
            {
                speed = 5.0f;

                Debug.LogWarning("Speed defaulted to 5");
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sr.flipX)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        if (health <= 0)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Barrier")
        {
            sr.flipX = !sr.flipX;
        }
        
    }
    public void EnemyDead()
    {
        health--;
        if(health <= 0)
        {
            Animation.SetBool(isDead, "true");
        }
    }
}
