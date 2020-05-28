using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Turret : MonoBehaviour
{
    public Transform projectileSpawnPoint;
    public Projectile projectilePrefab;
    public float projectileForce;

    public float projectileFireRate;
    float timeSinceLastFire = 0.0f;

    public int health;
    // Start is called before the first frame update
    void Start()
    {
        if (!projectileSpawnPoint)
        {
            Debug.LogWarning("No projectile spawn point found on enemy turret");
        }
        if (!projectilePrefab)
        {
            Debug.LogWarning("No projectile prefab on enemy turret");
        }
        if (projectileForce == 0)
        {
            projectileForce = 7.0f;
        }
        if (health <= 0)
        {
            health = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeSinceLastFire + projectileFireRate)
        {
            Fire();
            timeSinceLastFire = Time.time;
        }
    }

    void Fire()
    {
        Projectile temp = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

        temp.speed = projectileForce;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {

        }
    }
}
