using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_flyer : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    public float speed;
    public bool isFacingRight;
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
        rb.velocity = new Vector2(speed, rb.velocity.y);

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BarrierLeft")
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (collision.gameObject.tag == "BarrierRight")
        {
            rb.velocity = new Vector2(speed, 0);
        }
        if (collision.gameObject.tag == "BarrierUp")
        {
            rb.velocity = new Vector2(0, speed);
        }
        if (collision.gameObject.tag == "BarrierDown")
        {
            rb.velocity = new Vector2(0, -speed);
        }


    }
}
