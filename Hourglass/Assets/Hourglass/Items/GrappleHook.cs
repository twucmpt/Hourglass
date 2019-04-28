using System.Collections;
using System.Collections.Generic;
using Hourglass.Characters;
using UnityEngine;

namespace Hourglass.Items
{
    public class GrappleHook : Item
    {
        ProjectileSource projSrc;

        public int damage = 10;
        public float speed = 60;

        public GrappleHook(Character user) : base(4, user) { }

        public override void UsePrimary()
        {

            if (Cooldown() > 0) return;

            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (character.controller.facingRight && worldPoint.x > projSrc.transform.position.x)
            {
                Shoot();
            }
            else if (!character.controller.facingRight && worldPoint.x < projSrc.transform.position.x)
            {
                Shoot();
            }

        }

        private void Shoot()
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 offset = projSrc.transform.position - character.projectileOutput.transform.position;
            projSrc.Shoot(Vector3.Normalize(new Vector3(worldPoint.x - projSrc.transform.position.x + offset.x, worldPoint.y - projSrc.transform.position.y+ offset.y, 0)), speed, damage);
            StartCooldown();
        }

        public override void UseSecondary() { }

        public override void OnEquip()
        {
            projSrc = character.gameObject.AddComponent<ProjectileSource>();
            projSrc.output = character.projectileOutput;
            projSrc.colliders = new Collider2D[] { character.GetComponent<Collider2D>() };
            projSrc.projectileObject = Resources.Load<GameObject>("Prefabs/GrappleHook/GrappleHook");
        }
        public override void UsePassive() { }
        public override void OnDequip()
        {
            projSrc.Disable();
            UnityEngine.Object.Destroy(projSrc);
        }
    }
}