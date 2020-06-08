using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;

    int _score;
    int _lives;

    public int maxLives;

    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (_instance)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }


        _lives = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "TitleScreen")
            {
                SceneManager.LoadScene("Level1");
            }
            else if(SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("TitleScreen");
            }
        }
    }
    public void SpawnPlayer(Transform spawnLocation)
    {
            Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);

    }
    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }

    }
    public int score
    {
        get { return _score; }
        set
        {
            _score = value;
            Debug.Log("Score is change to " + _score);
        }
    }

    public int lives
    {
        get { return _lives; }
        set
        {
            _lives = value;
            if (_lives > maxLives)
                _lives = maxLives;
            Debug.Log("Lives is change to " + _score);
        }
    }
}
