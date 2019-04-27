using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hourglass.Characters;
using Hourglass.UI;
using UnityEngine;

namespace Hourglass
{
    public class Manager : MonoBehaviour
    {
        public Player player;
        public UIManager uiManager;
        public static Manager Instance { get; private set; }

    }
}
