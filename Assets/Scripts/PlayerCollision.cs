using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int health;
    GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = FindObjectOfType<GameManager>();
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
}
