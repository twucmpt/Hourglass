using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hourglass.Characters;

public class SpikeTrap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            Character victim = other.gameObject.GetComponent<Character>();
            victim.KnockBack(0, transform.position);
            victim.Damage(25);
        }
    }
}
