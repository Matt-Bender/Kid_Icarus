using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawn : MonoBehaviour
{
    public static GameObject heartPrefab;
    public GameObject featherPrefab;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, 3);

        if (random == 0)
        {
            Instantiate(heartPrefab, gameObject.transform.position, gameObject.transform.rotation);
        }
        else if (random == 1)
        {
            Instantiate(featherPrefab, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void spawnItem(GameObject gameObject)
    {
        Instantiate(heartPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}
