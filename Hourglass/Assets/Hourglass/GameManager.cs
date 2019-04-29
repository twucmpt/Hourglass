using Hourglass.Characters;
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
        "Level1"
        ,"Shop1"
        ,"Level2"
        ,"Level3"
        ,"EndGame"
        };
        private static int currentLevel = -1;


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
                Reset();
                UnityEngine.Object.Destroy(GameObject.FindGameObjectWithTag("Player"));
            }
        }

        public static bool IsCharacter(GameObject t)
        {
            try
            {
                t.GetComponent<Character>().ToString();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void LookAt(Transform obj, Vector3 loc)
        {
            Vector3 dir = loc - obj.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            obj.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }


        public static void Reset()
        {
            currentLevel = -1;
            SceneManager.LoadScene("StartMenu");
        }
    }

}
