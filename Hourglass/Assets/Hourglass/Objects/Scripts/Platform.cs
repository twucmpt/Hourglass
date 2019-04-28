using Hourglass.Physics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Rigidbody2D rb;
    List<(Collider2D collider, int dropTime)> holding = new List<(Collider2D collider, int dropTime)>();
    Collider2D collider2d;
    public int dropTime = 5;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();

    }

    void Update()
    {
        List<(Collider2D collider, int dropTime)> tempholding = new List<(Collider2D collider, int dropTime)>(holding);
        for(int i = 0; i < tempholding.Count; i++)
        {
            if (rb == null)
            {
                tempholding[i].collider.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            }
            else
            {
                tempholding[i].collider.GetComponent<Rigidbody2D>().velocity = rb.velocity;
            }

            if (tempholding[i].collider.IsTouching(collider2d))
            {
                tempholding[i] = (tempholding[i].collider, dropTime);
            }
            else
            {
                tempholding[i] = (tempholding[i].collider, tempholding[i].dropTime - 1);
                for (int j = 0; j < holding.Count; j++)
                {
                    if (holding[j].collider== tempholding[i].collider)
                    {
                        holding[j] = tempholding[i];
                        break;
                    }
                }
                if (tempholding[i].dropTime == 0)
                {
                    tempholding[i].collider.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                    holding.Remove(tempholding[i]);
                }
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
                foreach ((Collider2D collider, int dropTime) passenger in holding)
                {
                    if (passenger.collider == other) return;
                }
                holding.Add((other,dropTime));
                other.GetComponent<Rigidbody2D>().velocity = rb.velocity;
            }
        }
    }
}
