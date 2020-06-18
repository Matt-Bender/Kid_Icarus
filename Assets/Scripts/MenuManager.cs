using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    GameManager gm;

    public Button startButton;
    public Button quitButton;
    public Button returnButton;
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
            returnButton.onClick.AddListener(gm.GoTitle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
