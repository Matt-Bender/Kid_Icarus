using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
//public SpriteRenderer marioSprite;
public Transform leftProjectileSpawnPoint;
public Transform rightProjectileSpawnPoint;
public Projectile projectilePrefab;
public float speed;
public float lifetime;
public bool isFacingRight;
public SpriteRenderer pitSprite;

    public AudioClip fireSFX;
    public AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
{
    if (!leftProjectileSpawnPoint)
    {
        Debug.LogError("Missing projectileSpawn");
    }
    if (!rightProjectileSpawnPoint)
    {
        Debug.LogError("Missing projectileSpawn");
    }
    if (!projectilePrefab)
    {
        Debug.LogError("Missing projectilePrefab");
    }
    if (speed <= 0)
    {
        speed = 7.0f;
    }
        playerAudio = GetComponent<AudioSource>();
    }
void Update()
{
    if (Input.GetButtonDown("Fire1"))
    {
        createArrow();
    }
    if (pitSprite.flipX == true)
    {
        isFacingRight = false;
    }
    if (pitSprite.flipX == false)
    {
        isFacingRight = true;
    }
}
//transform.Rotate(Vector3.forward * 90);
void createArrow()
{
        playerAudio.clip = fireSFX;
        playerAudio.Play();
        if (isFacingRight)
    {
        Projectile temp =
        Instantiate(projectilePrefab,
        rightProjectileSpawnPoint.position,
        rightProjectileSpawnPoint.rotation);
        temp.transform.Rotate(Vector3.back * 90);
        temp.speed = speed;
        //Debug.Log("Shoot Right");
    }
    if (!isFacingRight)
    {
        Projectile temp =
        Instantiate(projectilePrefab,
        leftProjectileSpawnPoint.position,
        leftProjectileSpawnPoint.rotation);
        temp.transform.Rotate(Vector3.forward * 90);
        temp.speed = -7.0f;
        //Debug.Log("Shoot Left");
    }

}
}