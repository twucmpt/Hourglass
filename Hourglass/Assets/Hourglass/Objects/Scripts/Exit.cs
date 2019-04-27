using Hourglass;
using Hourglass.Scenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    GameObject levelManager;

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager");
        if (levelManager == null)
        {
            Debug.Log("Error. No level manager tagged.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (levelManager == null)
            {
                Debug.Log("Error. No level manager tagged.");
            }
            else
            {
                GameManager.NextLevel();
            }
        }
    }
}
