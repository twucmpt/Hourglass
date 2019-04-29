using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hourglass.Characters;

public class SpikeTrap : MonoBehaviour
{
    double timeUp = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            Character victim = collision.gameObject.GetComponent<Character>();
            victim.Damage(25);
        }
    }
}
