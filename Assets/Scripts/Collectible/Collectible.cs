using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType {
        HEART, LIVES, FEATHER, GODMODE}

    public CollectibleType type;


    GameManager instance;
    Movement move;
    CanvasManager cm;
    // Start is called before the first frame update
    void Start()
    {
        instance = FindObjectOfType<GameManager>();
        move = FindObjectOfType<Movement>();
        cm = FindObjectOfType<CanvasManager>();
    }
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        move.JumpForce /= 2;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (type)
            {
                case CollectibleType.HEART:
                    instance.score++;
                    cm.UpdateScore(instance.score);
                    break;
                case CollectibleType.GODMODE:
                    break;
                case CollectibleType.LIVES:
                    instance.lives++;
                    break;
                case CollectibleType.FEATHER:
                    move.JumpForce *= 2;
                    move.featherCount += 5;
                    break;
            }
            Destroy(gameObject);

        }
    }
    
    //void JumpNormalize()
    //{

    //    move.JumpForce /= 2;
    //    Debug.Log("JumpNormalize");
    //}
}
