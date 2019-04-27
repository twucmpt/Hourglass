using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{

    protected override void ComputeVelocity()
    {
        if (Input.GetButtonDown("Jump")) {
            Jump();
        }

        Move(Input.GetAxis("Horizontal"));

        UpdateVelocity();
    }
}