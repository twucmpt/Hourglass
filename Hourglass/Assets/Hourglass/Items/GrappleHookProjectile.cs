using System;
using System.Collections;
using System.Collections.Generic;
using Hourglass.Characters;
using UnityEngine;

namespace Hourglass.Items
{
    public class GrappleHookProjectile : Projectile
    {

        private Transform target;
        private Transform t;
        private bool grapple = false;
        private bool pull = false;
        public float grappleSpeed = 1;

        private Vector3[] previousPos = new Vector3[10];

        private float gravMod = 0.5f;

        private void Update()
        {
            if (grapple)
            {
                PullTowards(t, target, source.GetComponent<Character>().projectileOutput.transform);
            }
            else if(pull)
            {
                PullTowards(t, target);
            }

        }

        private void PullTowards(Transform t, Transform target, Transform center=null)
        {
            if(center == null)
            {
                center = t;
            }

            //Debug.Log(Vector3.Distance(previousPos[previousPos.Length - 1], center.position));
            if (Vector3.Distance(center.position, target.position) > 0 && Vector3.Distance(previousPos[previousPos.Length-1], center.position) > 0.02f)
            {
                
                Vector3 dir = Vector3.Normalize(new Vector3(target.position.x - center.position.x, target.position.y - center.position.y, 0));
                t.GetComponent<Character>().SetVelocity(dir * grappleSpeed);
                t.GetComponent<Character>().controller.ragdoll = true;
            }
            else
            {
                Disable();
                grapple = false;

                source.RemoveProjectile(gameObject);
                Destroy(gameObject);
            }

            //Store previous locations
            for (int i = previousPos.Length - 1; i > 0; i--)
            {
                previousPos[i] = previousPos[i - 1];
            }
            previousPos[0] = center.position;
        }

        protected override void Collision(Collider2D other)
        {
            Destroy(GetComponent<Rigidbody2D>());
            rb = null;

            if (GameManager.IsCharacter(other.gameObject))
            {
                other.gameObject.GetComponent<Character>().Damage(damage);
                PullTarget(other.gameObject.GetComponent<Character>());
            }
            else
            {
                Grapple(other);
            }
        }

        private void Grapple(Collider2D other)
        {
            t = source.transform;
            target = transform;
            source.transform.GetComponent<Character>().controller.gravityModifier = source.transform.GetComponent<Character>().controller.gravityModifier * gravMod;
            grapple = true;
        }

        private void PullTarget(Character character)
        {
            t = character.transform;
            t.GetComponent<Character>().controller.gravityModifier = t.GetComponent<Character>().controller.gravityModifier * gravMod;
            target = source.transform;
            pull = true;
        }

        public override void Disable()
        {
            if (grapple || pull)
            {
                t.GetComponent<Character>().controller.ragdoll = false;
                t.GetComponent<Character>().controller.gravityModifier = t.GetComponent<Character>().controller.gravityModifier / gravMod;
            }
        }
    }
}