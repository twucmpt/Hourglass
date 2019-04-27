using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hourglass.Scenes {
    public class SceneManager
    {
        public static void LoadScene(string name)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(name);
        }
    }
}
