using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Hourglass.Items;

namespace Hourglass.Characters
{
    public abstract class Character : MonoBehaviour
    {

        public CharacterController controller;
        public int initialSand = 600;
        public int baseDamage = 10;
        public float attackSpeed = 0.6f;

        private float attackCooldown = 0;
        private float sand = 0;
        private bool alive = true;
        public bool timer;
        protected List<Item> items = new List<Item>();
        private SpriteRenderer sr;

        private float flicker = 0;

        protected void Awake()
        {
            sand = initialSand;
            controller = GetComponent<CharacterController>();
            sr = GetComponent<SpriteRenderer>();
        }

        protected void Update()
        {
            if (alive)
            {
                if (timer)
                {
                    CountDown();
                }
            }
            if (attackCooldown > 0)
            {
                attackCooldown -= Time.deltaTime;
            }
            if (flicker != 0)
            {
                Flicker();
            }
        }

        protected virtual void CountDown()
        {
            ReduceTime();
            if (sand <= 0)
            {
                Die();
            }
        }

        private void ReduceTime()
        {
            sand -= Time.deltaTime;
        }

        private void Die()
        {
            alive = false;
            sand = 0;
        }

        public void AddSand(int amount)
        {
            sand += amount;
        }

        public void RemoveSand(int amount)
        {
            sand -= amount;
        }

        public int GetSand()
        {
            return (int)sand;
        }

        public void Damage(int damage)
        {
            if (flicker == 0)
            {
                RemoveSand(damage);
                DamageResponse();
            }
        }

        protected virtual void DamageResponse()
        {
            FlickerAnimation(0.8f);
        }

        private void FlickerAnimation(float time)
        {
            flicker = time;
        }

        private void Flicker()
        {
            flicker -= Time.deltaTime;
            sr.enabled = !sr.enabled;

            if (flicker <= 0 && IsGrounded())
            {
                sr.enabled = true;
                flicker = 0;
            }
            if(flicker == 0)
            {
                sr.enabled = true;
            }
        }

        public void SetLocation(Vector2 loc)
        {
            transform.position = new Vector3(loc.x, loc.y, transform.position.z);
        }

        public Vector2 GetLocation()
        {
            return new Vector2(transform.position.x, transform.position.y);
        }

        public void SetVelocity(Vector2 velocity)
        {
            controller.VelocityOverride(velocity);
        }

        public Vector2 GetVelocity()
        {
            return controller.GetVelocity();
        }

        public bool IsGrounded()
        {
            return controller.IsGrounded();
        }

        public Item GetItem(int id)
        {
            return items[id];
        }

        protected virtual void Attack(Character target)
        {
            if (attackCooldown <= 0)
            {
                attackCooldown = attackSpeed;
                target.KnockBack(baseDamage, transform.position);
                target.Damage(baseDamage);
            }
        }

        private void KnockBack(int baseDamage, Vector3 position)
        {
            if (flicker == 0)
            {
                controller.ragdoll = true;

                float vertical = 4;
                float horizontal = 12;



                Vector3 knockbackDirection = Vector3.Normalize(new Vector3(transform.position.x - position.x, transform.position.y - position.y, 0));

                Vector3 knockback = Vector3.Normalize(new Vector3(knockbackDirection.x, 0, 0));
                knockback = new Vector3(knockback.x * horizontal, vertical, 0);

                //Variant of knockback
                //float mutltiplier = 6;
                //float boost = 4;
                //Vector3 knockback = new Vector3(knockbackDirection.x*mutltiplier, knockbackDirection.y*mutltiplier+boost, 0);

                SetVelocity(knockback);
            }
        }
    }
}
