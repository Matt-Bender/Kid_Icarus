using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    //turret shoots every fireRate seconds
    public float fireRate;

    //projectile being fired
    public enemy_projectile projectilePrefab;

    //location to spawn projectile
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;

    bool projectileFired = false;

    public bool shootLeft;
    //target to shoot towrads (player)
    public GameObject target;

    float timeSinceLastFire = 0;

    public SpriteRenderer rangedEnemy;

    // Start is called before the first frame update
    void Start()
    {
        if (!target)
        {
            target = GameObject.FindWithTag("Player");

            shootDirectionCheck();
        }
        if (fireRate <= 0)
        {
            fireRate = 1;
            Debug.Log("fireRate set to 1");
        }
    }

    void shootDirectionCheck()
    {
        if (target)
        {
            if (target.transform.position.x < transform.position.x)
            {
                shootLeft = true;   //shoot left
            }
            else
            {
                shootLeft = false;  //shoot right
            }
        }
    }

    void fireProjectile()
    {

            shootDirectionCheck();
            if (shootLeft)
            {
                Instantiate(projectilePrefab, leftSpawnPoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else
            {
                //rotate projectile 180 degrees
                Instantiate(projectilePrefab, rightSpawnPoint.position, Quaternion.Euler(new Vector3(0, 180.0f, 0)));
            }
            projectileFired = false;
       

    }
    void flipTurret()
    {
        if (target)
        {
            if (target.transform.position.x < transform.position.x && rangedEnemy.flipX == true)
            {
                rangedEnemy.flipX = !rangedEnemy.flipX;
            }
            if (target.transform.position.x > transform.position.x && rangedEnemy.flipX == false)
            {
                rangedEnemy.flipX = !rangedEnemy.flipX;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(projectileFired == false)
            {
                projectileFired = true;
                Invoke("fireProjectile", fireRate);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        flipTurret();
    }
}
