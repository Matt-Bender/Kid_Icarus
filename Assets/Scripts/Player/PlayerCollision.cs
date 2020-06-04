using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int health;

    Rigidbody2D myRigidBody;
    public Transform tpRight;
    public Transform tpLeft;
    public float tpOffset;

    public SpriteRenderer pitSprite;

    Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -15)
        {
            GameManager.instance.lives -= 1;
            GameManager.instance.SpawnPlayer(spawnPoint);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            GameManager.instance.lives -= 1;
            GameManager.instance.SpawnPlayer(spawnPoint);
            Destroy(gameObject);
        }



        // Did GameObject tagged ”Enemy” hit Character
        if (c.gameObject.tag == "Enemy" || c.gameObject.tag == "Enemy_Projectile")
{
            health -= 1; // Remove 1 health on Collision
                         // Check if health is ZERO
            if (health <= 0)
            {
                // Destroy GameObject Script is attached to
                // when health is ZERO (Character)
                Destroy(gameObject);
            }
        }
    }
    //teleport across screen
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //going left
        if (pitSprite.flipX == true)
        {
            if (collision.gameObject.name == "Teleport Left")
            {
                myRigidBody.transform.position = new Vector2(tpRight.transform.position.x - tpOffset, myRigidBody.transform.position.y);
            }
        }
        //going right
        else if(pitSprite.flipX == false)
        {
            if (collision.gameObject.name == "Teleport Right")
            {
                myRigidBody.transform.position = new Vector2(tpLeft.transform.position.x + tpOffset, myRigidBody.transform.position.y);
            }
        }


    }

}
