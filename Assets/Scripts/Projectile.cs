using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float lifeTime;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (lifeTime <= 0)
        {
            lifeTime = 2.0f;
        }
        //speed = 4;
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifeTime);
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        // Check if "Projectile" GameObject hits something not named "Player"
        // - Stops "Projectile" GameObject from being destroyed if it hits "Player" GameObject
        if (c.gameObject.tag != "Player")
        {
            //Debug.Log("Collision");
            // Destory GameObject Script is attached to
            Destroy(gameObject);
        }
    }
}

////public SpriteRenderer marioSprite;
//public Transform leftProjectileSpawnPoint;
//public Transform rightProjectileSpawnPoint;
//public Arrow projectilePrefab;
//public float speed;
//public float lifetime;
//public bool isFacingRight;
//public Movement movement;

//// Start is called before the first frame update
//void Start()
//{
//    if (!leftProjectileSpawnPoint)
//    {
//        Debug.LogError("Missing projectileSpawn");
//    }
//    if (!rightProjectileSpawnPoint)
//    {
//        Debug.LogError("Missing projectileSpawn");
//    }
//    if (!projectilePrefab)
//    {
//        Debug.LogError("Missing projectilePrefab");
//    }
//    if (speed <= 0)
//    {
//        speed = 7.0f;
//    }
//}
//void Update()
//{
//    if (Input.GetButtonDown("Fire1"))
//    {
//        createArrow();
//    }
//    if (movement.marioSprite.flipX == true)
//    {
//        isFacingRight = false;
//    }
//    if (movement.marioSprite.flipX == false)
//    {
//        isFacingRight = true;
//    }
//    createArrow();
//}
////transform.Rotate(Vector3.forward * 90);
//void createArrow()
//{
//    if (isFacingRight)
//    {
//        Projectile temp =
//        Instantiate(projectilePrefab,
//        rightProjectileSpawnPoint.position,
//        rightProjectileSpawnPoint.rotation);
//        temp.transform.Rotate(Vector3.back * 90);
//        temp.speed = speed;
//        Debug.Log("Shoot Right");
//    }
//    if (!isFacingRight)
//    {
//        Projectile temp =
//        Instantiate(projectilePrefab,
//        leftProjectileSpawnPoint.position,
//        leftProjectileSpawnPoint.rotation);
//        temp.speed = -7.0f;
//        temp.transform.Rotate(Vector3.forward * 90);
//        Debug.Log("Shoot Left");
//    }

//}
//}
