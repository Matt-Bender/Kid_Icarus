using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{

    GameManager gm;
    public Button startButton;
    public Button quitButton;
    public Button returnButton;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (startButton)
        {
            startButton.onClick.AddListener(gm.StartGame);
        }
        if (quitButton)
        {
            quitButton.onClick.AddListener(gm.QuitGame);
        }
        if (returnButton)
        {
            returnButton.onClick.AddListener(gm.QuitGame);
        }
    }
    public void UpdateScore(int score)
    {
        scoreText.text = "Score - " + score.ToString();
    }
    //public void UpdateLives(int lives)
    //{
    //    livesText.text = "Lives - " + lives.ToString();
    //}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
        if (pauseMenu)
        {
            if (pauseMenu.activeSelf)
            {
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }


    }
}
