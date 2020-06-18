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

    public AudioClip titleScreen;
    public AudioClip level;
    public AudioSource pauseAudio;
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
        pauseAudio = GetComponent<AudioSource>();
        pauseAudio.clip = level;
        pauseAudio.Play();
    }
    public void UpdateScore(int score)
    {
        scoreText.text = "Score - " + score.ToString();
    }
    public void UpdateLives(int lives)
    {
        livesText.text = "Lives - " + lives.ToString();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            if (pauseMenu.activeSelf)
            {
                pauseAudio.clip = titleScreen;
                pauseAudio.Play();
            }
            else
            {
                pauseAudio.clip = level;
                pauseAudio.Play();
            }

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
