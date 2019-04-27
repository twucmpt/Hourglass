using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : CharacterMovement
{

    protected override void ComputeVelocity()
    {
        UpdateVelocity();
    }

}
