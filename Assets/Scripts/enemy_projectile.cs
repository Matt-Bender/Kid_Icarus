using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_projectile : MonoBehaviour
{
    public float projectileSpeed;
    public float projectileLifeTime;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //destroy projectile after lifetime
        Destroy(gameObject, projectileLifeTime);

        projectileSpeed = 5.0f;

        rb = GetComponent<Rigidbody2D>();
        //check if rotation has been changed for direction
        if (transform.localRotation.y == 0)
        {
            rb.AddForce(Vector2.left * projectileSpeed, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.right * projectileSpeed, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        //if (c.gameObject.tag == "Enemy" || c.gameObject.tag == "EnemySquish")
        //{
        //    Destroy(c.gameObject);
        //}
    }
}
