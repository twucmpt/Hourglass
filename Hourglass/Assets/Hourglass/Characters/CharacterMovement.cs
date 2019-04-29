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
        public bool spriteFacingRight = true;
        public float flipSensitivity = 0.01f;
        public bool facingRight = true;

        private float move;
        private float moveOverrideValue;
        private bool moveOverride = false;
        private int flipDelay = 20;
        private int flipDelayCount = 0;

        private bool velocityOverride = false;


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
                    if (spriteFacingRight)
                    {
                        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                    }
                    else
                    {
                        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
                    }
                    facingRight = true;
                }
                else if (move.x < -flipSensitivity)
                {
                    if (spriteFacingRight)
                    {
                        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
                    }
                    else
                    {
                        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                    }
                    facingRight = false;
                }
            }
            if(flipvalue != spriteRenderer.flipX)
            {
                flipDelayCount = flipDelay;
            }

            if (moveOverride)
            {
                move.x = moveOverrideValue;
                moveOverride = false;
            }

            animator.SetBool("Grounded", grounded);
            animator.SetFloat("Speed", Mathf.Abs(velocity.x) / maxSpeed);

            if (!velocityOverride)
            {
                targetVelocity = move * maxSpeed;
            }
            else
            {
                velocityOverride = false;
            }

        }

        // Functions for Character Controller

        protected void Move(float value)
        {
            move = value;
        }

        protected void Jump()
        {
            if (grounded && !velocityOverride)
            {
                velocity.y = jumpTakeOffSpeed;
            }
        }

        // General Movement / Physics Functions

        public void VelocityOverride(Vector2 v)
        {
            if (!velocityOverride)
            {
                velocityOverride = true;
                targetVelocity = v;
                velocity = v;
            }
        }

        public void MoveOverride(float value)
        {
            moveOverride = true;
            moveOverrideValue = value;
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