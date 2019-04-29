using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hourglass;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        GameManager.NextLevel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
