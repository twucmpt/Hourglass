using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hourglass;
using Hourglass.Characters;
using TMPro;

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

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            Player player = (Player)FindObjectsOfType(typeof(Player))[0];
            TextMeshProUGUI[] tms = GetComponentsInChildren<TextMeshProUGUI>();
            tms[2].SetText("Sand Remaining: " + player.GetSand() + " Seconds");
        }
        catch { }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
