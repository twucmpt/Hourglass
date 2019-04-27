using Hourglass.Scenes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hourglass
{
    public class GameManager
    {

        private static string[] levelOrder = new string[]
        {
        "Level1",
        "Shop1"
        };
        private static int currentLevel = 0;


        public static void NextLevel()
        {
            currentLevel++;
            if(currentLevel < levelOrder.Length)
            {
                SceneManager.LoadScene(levelOrder[currentLevel]);
            }
            else
            {
                Debug.Log("Game Complete. You Win.");
            }
        }
    }
}
