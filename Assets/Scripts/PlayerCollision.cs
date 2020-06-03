using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int health;
    GameManager instance;

    Rigidbody2D myRigidBody;
    public Transform tpRight;
    public Transform tpLeft;
    public float tpOffset;

    public SpriteRenderer pitSprite;
    // Start is called before the first frame update
    void Start()
    {
        instance = FindObjectOfType<GameManager>();
        myRigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        // Did GameObject tagged ”Enemy” hit Character
        if (c.gameObject.tag == "Enemy")
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
