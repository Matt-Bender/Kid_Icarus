using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_walker : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    public float speed;
    public bool isFacingRight;
    Animator anim;
    public int health;

    public AudioSource walkerAudio;
    public AudioClip walkerClip;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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
                speed = 0.5f;

                Debug.LogWarning("Speed defaulted to 0.5");
            }
            if (health <= 0)
        {
            health = 1;
            //Debug.Log("Enemy: Defaulting health to " + health);
        }
        walkerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (sr != null)
        {
            if (sr.flipX)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Barrier")
        {
            sr.flipX = !sr.flipX;
        }
        
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        // Did GameObject tagged ”Projectile” hit Enemy
        if (c.gameObject.tag == "Projectile")
        {
            // Destroy Projectile that collided
            Destroy(c.gameObject);
            health -= 1; // Remove 1 health on Collision
                         // Check if health is ZERO
            if (health <= 0)
            {
                walkerAudio.clip = walkerClip;
                walkerAudio.Play();
                anim.SetBool("isDead", true);
                // Destroy GameObject Script is attached to
                // when health is ZERO (Enemy)
                
            }
        }
    }

}
