using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hourglass.Characters;
using UnityEngine;

namespace Assets.Hourglass
{
    class Manager : MonoBehaviour
    {
        public Player player;
        public static Manager Instance { get; private set; }

        public void Awake()
        {
            player = GetComponent<Player>();
        }
    }
}
