using Hourglass.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hourglass.Scenes
{
    //Handles any setup at the beginning of a new level
    public class LevelManager : MonoBehaviour
    {

        public bool timer = true;

        private void Start()
        {
            Manager manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();

            //Starts the player at this object's location
            manager.player.SetLocation(new Vector2(transform.position.x, transform.position.y));
            manager.player.SetVelocity(new Vector2(0, 0));
            manager.player.timer = timer;

        }
    }
}
