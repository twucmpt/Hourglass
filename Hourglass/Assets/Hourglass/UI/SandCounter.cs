using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Hourglass.Characters;

namespace Hourglass.UI
{
    public class SandCounter : MonoBehaviour
    {

        private UnityEngine.UI.Text text;
        public Character character;

        void Awake()
        {
            text = GetComponent<UnityEngine.UI.Text>();
        }

        void Update()
        {
            text.text = character.GetSand().ToString();
        }



    }
}
