using Hourglass.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hourglass.Scenes
{
    //Handles any setup at the beginning of a new level
    public class LevelManager : MonoBehaviour
    {
        private void Start()
        {
            //Starts the player at this object's location
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().SetLocation(new Vector2(transform.position.x, transform.position.y));
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().SetVelocity(new Vector2(0, 0));

        }
    }
}
