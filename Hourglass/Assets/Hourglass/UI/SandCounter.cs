using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Hourglass.Characters;

namespace Hourglass.UI
{
    public class SandCounter : MonoBehaviour
    {

        private UnityEngine.UI.Text text;
        public Player character;

        void Awake()
        {
            character = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>().player;
            text = GetComponent<UnityEngine.UI.Text>();
        }

        void Update()
        {
            text.text = character.GetSand().ToString();
        }



    }
}
