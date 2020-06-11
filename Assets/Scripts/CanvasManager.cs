using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{

    GameManager gm;
    public Button startButton;
    public Button quitButton;
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
    }
}
