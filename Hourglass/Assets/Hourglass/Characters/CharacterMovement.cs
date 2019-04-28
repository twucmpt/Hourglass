using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Modified from https://unity3d.com/learn/tutorials/topics/2d-game-creation/scripting-gravity?playlist=17093

using Hourglass.Physics;

namespace Hourglass.Characters
{
    public class CharacterMovement : PhysicsObject
    {
        public float maxLandSpeed = 7;
        public float maxAirSpeed = 3;
        public float jumpTakeOffSpeed = 7;
        public bool facingRight = true;
        public float flipSensitivity = 0.01f;

        private float move;
        private int flipDelay = 20;
        private int flipDelayCount = 0;

        private SpriteRenderer spriteRenderer;
        private Animator animator;

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        // This should be called every ComputeVelocity

        protected void UpdateVelocity()
        {
            float maxSpeed = 0;
            if (grounded)
            {
                maxSpeed = maxLandSpeed;
            }
            else
            {
                maxSpeed = maxAirSpeed;
            }

            Vector2 move = Vector2.zero;

            move.x = this.move;

            //Flip
            if(flipDelayCount > 0)
            {
                flipDelayCount -= 1;
            }
            bool flipvalue = spriteRenderer.flipX;
            if (flipDelayCount == 0)
            {
                if (move.x > flipSensitivity)
                {
                    spriteRenderer.flipX = !facingRight;
                }
                else if (move.x < -flipSensitivity)
                {
                    spriteRenderer.flipX = facingRight;
                }
            }
            if(flipvalue != spriteRenderer.flipX)
            {
                flipDelayCount = flipDelay;
            }

            animator.SetBool("Grounded", grounded);
            animator.SetFloat("Speed", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }

        // Functions for Character Controller

        protected void Move(float value)
        {
            move = value;
        }

        protected void Jump()
        {
            if (grounded)
            {
                velocity.y = jumpTakeOffSpeed;
            }
        }

        // General Movement / Physics Functions

        public void VelocityOverride(Vector2 v)
        {
            targetVelocity = v;
            velocity = v;
        }

        public Vector2 GetVelocity()
        {
            return velocity;
        }

        public bool IsGrounded()
        {
            return grounded;
        }
    }
}