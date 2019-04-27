using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandCounter : MonoBehaviour
{

    private UnityEngine.UI.Text text;
    public Player player;

    void Awake()
    {
        text = GetComponent<UnityEngine.UI.Text>();
    }

    void Update()
    {
        text.text = player.GetSand().ToString();
    }



}
