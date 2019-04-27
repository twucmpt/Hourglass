using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hourglass.Characters
{
    public class PlayerController : CharacterController
    {
        protected override void MakeMovements()
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }

            Move(Input.GetAxis("Horizontal"));
        }
    }
}