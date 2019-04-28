using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Hourglass.Characters
{
    public class NPCController : CharacterController
    {

        private Vector2 previousPos;
        public float waitTimeMax = 10;
        public float wanderTimeMax = 10;
        private float waitTime = 0;
        private float timeWaited = 0;
        private float wanderTime = 0;
        private float timeWandered = 0;
        private float wander = 0;
        private Vector2 previousJumpPos;


        protected override void MakeMovements()
        {
            if (goToTarget)
            {
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
        
            previousPos = transform.position;
        }

        private void StartWander()
        {
            Debug.Log("Start Wander: " + wanderTime);
            previousPos = new Vector2(previousPos.x+10, previousPos.y+10);
            timeWandered = 0;
            wanderTime = Random.Range(0, wanderTimeMax);
            float sign = 0;
            if (Random.Range(-1, 1) < 0)
            {
                sign = -1;
            }
            else
            {
                sign = 1;
            }
            wander = sign * Random.Range(0.5f, 1);
        }

        private void StartWait()
        {
            Debug.Log("Start Wait");
            timeWaited = 0;
            waitTime = Random.Range(0, waitTimeMax);
        }

        private void StuckJump()
        {
            //Jump if stuck
            if (Vector2.Distance(previousPos, transform.position) < 0.1f)
            {
                if (Vector2.Distance(previousJumpPos, transform.position) > 0.1f)
                {
                    previousJumpPos = transform.position;
                    Jump();
                }
                else if(wanderTime > 0 && !goToTarget)
                {
                    StartWander();
                }
            }
        }

        private void GoToTarget()
        {
            if (Vector2.Distance(targetLoc, transform.position) < 0.5f)
            {
                goToTarget = false;
                StartWait();
                Move(0);
            }
            else
            {
                StuckJump();

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