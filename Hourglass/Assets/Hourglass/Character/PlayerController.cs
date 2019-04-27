using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Modified from https://unity3d.com/learn/tutorials/topics/2d-game-creation/scripting-gravity?playlist=17093

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