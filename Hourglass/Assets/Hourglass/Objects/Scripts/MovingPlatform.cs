using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    Transform targets;
    int targetIdx;
    bool forward = true;
    private Vector3 targetLoc;
    public float speed = 2f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            Transform child = transform.parent.GetChild(i);
            if (child.name.Equals("Targets"))
            {
                targets = child;
            }
        }
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTargetLoc();
        MoveTowardsTargetLoc();

    }

    private void MoveTowardsTargetLoc()
    {
        Vector3 direction = Vector3.Normalize(new Vector3(targetLoc.x - transform.position.x, targetLoc.y - transform.position.y, targetLoc.z - transform.position.z));
        rb.velocity = direction * speed;
        /*if(Vector3.Distance(transform.position, targetLoc) > direction.x*speed+direction.y*speed)
        {
            transform.position = transform.position + direction * speed;
        }
        else
        {
            transform.position = targetLoc;
        }*/
    }

    private void UpdateTargetLoc()
    {
        targetLoc = targets.GetChild(targetIdx).position;

        //Has destination been reached?
        if (Vector3.Distance(transform.position, targetLoc) < 0.1f)
        {

            //Switch direction if needed
            if (targetIdx == targets.childCount - 1)
            {
                forward = false;
            }
            if (targetIdx == 0)
            {
                forward = true;
            }

            //Select next target
            if (forward)
            {
                targetIdx++;
            }
            else
            {
                targetIdx--;
            }

        }

    }

}
