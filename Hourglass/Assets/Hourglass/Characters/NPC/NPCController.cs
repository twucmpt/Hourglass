using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Hourglass.Characters
{
    public class NPCController : CharacterController
    {

        private Vector2[] previousPos = new Vector2[10];

        public float minX, maxX, minY, maxY;
        public bool useXRange = false;
        public bool useYRange = false;

        //Wait
        public float waitTimeMax = 10;
        private float waitTime = 0;
        private float timeWaited = 0;

        //Wander
        public float wanderTimeMax = 10;
        private float wanderTime = 0;
        private float timeWandered = 0;
        private float wander = 0;

        public string state;


        private Vector2 previousJumpPos;


        protected override void MakeMovements()
        {
            if (goToTarget)
            {
                //Reset
                waitTime = 0;
                timeWaited = 0;
                wanderTime = 0;
                timeWandered = 0;

                GoToTarget();
            }
            else
            {
                if (waitTime != 0)
                {
                    if (timeWaited > waitTime)
                    {
                        StartWander();
                        waitTime = 0;
                        timeWaited = 0;
                    }
                    else
                    {
                        Move(0);
                        timeWaited += Time.deltaTime;
                    }
                }
                else if (wanderTime != 0)
                {
                    if (timeWandered > wanderTime)
                    {
                        StartWait();
                        wanderTime = 0;
                        timeWandered = 0;
                    }
                    else
                    {
                        Move(wander);
                        timeWandered += Time.deltaTime;

                        StuckJump();
                    }
                }

            }

            //Range constraints
            if(useXRange)
            {
                if (transform.position.x > maxX)
                {
                    StartWander(-1);
                    transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
                }
                else if (transform.position.x < minX)
                {
                    StartWander(1);
                    transform.position = new Vector3(minX, transform.position.y, transform.position.z);
                }
            }
            if (useYRange)
            {
                if (transform.position.y > maxY)
                {
                    StartWander();
                    transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
                }
                else if (transform.position.y < minY)
                {
                    StartWander();
                    transform.position = new Vector3(transform.position.x, minY, transform.position.z);
                }
            }

            //Store previous locations
            for (int i = previousPos.Length - 1; i > 0; i--)
            {
                previousPos[i] = previousPos[i - 1];
            }
            previousPos[0] = transform.position;

        }

        private void StartWander(int sign = 0)
        {
            previousPos[0] = new Vector2(previousPos[previousPos.Length - 2].x + 10, previousPos[previousPos.Length - 2].y + 10);
            timeWandered = 0;
            wanderTime = Random.Range(0.1f, wanderTimeMax);
            if (sign == 0)
            {
                if (Random.Range(-1, 1) < 0)
                {
                    sign = -1;
                }
                else
                {
                    sign = 1;
                }
            }
            wander = sign * Random.Range(0.5f, 1);
            state = "Wandering " + wander + " for " + wanderTime;
        }

        private void StartWait()
        {
            timeWaited = 0;
            waitTime = Random.Range(0.1f, waitTimeMax);
            state = "Waiting for " + waitTime;
        }

        private void StuckJump()
        {
            //Jump if stuck
            if (Vector2.Distance(previousPos[previousPos.Length - 1], transform.position) < 0.001f)
            {
                TryJump();
            }
        }

        private void TryJump()
        {
            if (IsGrounded())
            {
                if (Vector2.Distance(previousJumpPos, transform.position) > 0.1f)
                {
                    previousJumpPos = transform.position;
                    Jump();
                }
                else if (wanderTime == 0)
                {
                    StartWander();
                    goToTarget = false;
                }
                else
                {
                    previousJumpPos = transform.position;
                    Jump();
                }
            }
        }

        private void GoToTarget()
        {
            state = "Targetting";
            if (Vector2.Distance(targetLoc, transform.position) < 0.5f)
            {
                goToTarget = false;
                StartWait();
                Move(0);
            }
            else
            {
                StuckJump();

                //Poor attempt to follow target on floating platforms
                if((targetLoc.y - 0.5f) > transform.position.y)
                {
                    previousJumpPos = transform.position;
                    TryJump();
                }

                //Move in horizontal direction towards target
                int dir = 0;
                if (targetLoc.x - transform.position.x > 0)
                {
                    dir = 1;
                }
                else
                {
                    dir = -1;
                }
                Move(dir);

            }
        }
    }
}