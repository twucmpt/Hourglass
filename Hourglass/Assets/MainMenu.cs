using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hourglass;
using Hourglass.Characters;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public AudioClip victory;
    public AudioClip defeat;

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
        try //if end game scene
        {
            Player player = (Player)FindObjectsOfType(typeof(Player))[0];
            TextMeshProUGUI[] tms = GetComponentsInChildren<TextMeshProUGUI>();
            tms[2].SetText("Sand Remaining: " + player.GetSand() + " Seconds");
            AudioSource music = Camera.main.GetComponent<AudioSource>();

            if (player.GetSand() > 0)
                music.clip = victory;
            else music.clip = defeat;
        }
        catch { }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
