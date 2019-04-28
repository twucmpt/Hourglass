using Hourglass.Physics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Rigidbody2D rb;
    List<Collider2D> holding = new List<Collider2D>();
    Collider2D collider2d;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();

    }

    void Update()
    {
        List<Collider2D> tempholding = new List<Collider2D>(holding);
        foreach (Collider2D passenger in tempholding)
        {
            if (passenger.IsTouching(collider2d))
            {
                //passenger.transform.position = new Vector3(passenger.transform.position.x, transform.position.y+2, passenger.transform.position.z);
                if (rb == null)
                {
                    passenger.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
                }
                else
                {
                    passenger.GetComponent<Rigidbody2D>().velocity = rb.velocity;
                }
            }
            else
            {
                holding.Remove(passenger);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool shouldHold = false;
        try
        {
            other.GetComponent<PhysicsObject>();
            shouldHold = true;
        }
        catch(MissingComponentException)
        {

        }
        if (shouldHold)
        {
            if ((other.transform.position.y - transform.position.y) > 0)
            {
                foreach (Collider2D passenger in holding)
                {
                    if (passenger == other) return;
                }
                holding.Add(other);
                other.GetComponent<Rigidbody2D>().velocity = rb.velocity;
            }
        }
    }
}
