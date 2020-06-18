using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public AudioSource pitAudio;
    public AudioClip pitClip;
    // Start is called before the first frame update
    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    void Start()
    {
        pitAudio = GetComponent<AudioSource>();
        pitAudio.clip = pitClip;
        pitAudio.Play();
        Invoke("GameOver", 2.5f);
    }
}
