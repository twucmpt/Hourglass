using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hourglass.Characters
{
    public abstract class CharacterController : CharacterMovement
    {
        public Vector2 targetLoc;
        public bool goToTarget = false;

        protected abstract void MakeMovements();

        protected override void ComputeVelocity()
        {
            MakeMovements();
            UpdateVelocity();
        }

    }
}