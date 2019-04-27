using Hourglass.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hourglass.Scenes
{
    public class LevelManager : MonoBehaviour
    {

        public string nextLevel;

        private void Start()
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().SetLocation(new Vector2(transform.position.x, transform.position.y));
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().SetVelocity(new Vector2(0, 0));

        }

        public void NextLevel()
        {
            if(nextLevel != null)
            {
                SceneManager.LoadScene(nextLevel);
            }
            else
            {
                Debug.Log("Error. No next scene defined in Level Manager.");
            }
        }
    }
}
