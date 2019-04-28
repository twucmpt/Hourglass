using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hourglass.Characters
{
    public class NPC : Character
    {
        private Character target;
        public float sight = 5;
        public float interactionDistance = 0.5f;


        protected new void Update()
        {
            base.Update();
            if (target != null)
            {
                if (Vector2.Distance(target.transform.position, transform.position) < sight)
                {
                    controller.goToTarget = true;
                    controller.targetLoc = target.transform.position;
                }
                if (Vector2.Distance(target.transform.position, transform.position) < interactionDistance)
                {
                    Interact(target);
                }
            }

        }

        protected virtual void Interact(Character target)
        {
            
        }

        public void Target(Character t)
        {
            target = t;
        }

        protected override void CountDown()
        {
            //They don't lose sand over time
        }
    }
}