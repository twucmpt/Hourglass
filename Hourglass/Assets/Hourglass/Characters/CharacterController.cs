using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hourglass.Characters
{
    public abstract class CharacterController : CharacterMovement
    {
        protected abstract void MakeMovements();

        protected override void ComputeVelocity()
        {
            MakeMovements();
            UpdateVelocity();
        }

    }
}