using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject playerPrefab;

    private bool spawnPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.lives = 3;
        //    GameManager.instance.DestroyPlayer();

        if (playerPrefab && spawnPoint)
        {
            // Instantiate (Create) 'Character' GameObject
            GameManager.instance.SpawnPlayer(spawnPoint);
        }
        else
            // Prints a message to Console (Shortcut: Control+Shift+C)
            Debug.LogError("Missing Player Prefab or SpawnPoint");

}

    // Update is called once per frame
    void Update()
    {

    }
}
