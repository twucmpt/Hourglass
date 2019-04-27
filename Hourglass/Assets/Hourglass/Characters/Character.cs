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

        private float sand = 0;
        private bool alive = true;
        protected List<Item> items = new List<Item>();

        protected void Awake()
        {
            sand = initialSand;
            controller = GetComponent<CharacterController>();
        }

        protected void Update()
        {
            if (alive)
            {
                ReduceTime();
                if (sand <= 0)
                {
                    Die();
                }
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
            RemoveSand(damage);
            //Play damage animation or something
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

    }
}
