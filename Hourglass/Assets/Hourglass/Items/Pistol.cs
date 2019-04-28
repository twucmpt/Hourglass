using System.Collections;
using System.Collections.Generic;
using Hourglass.Characters;
using UnityEngine;

namespace Hourglass.Items
{
    public class Pistol : Item
    {
        ProjectileSource projSrc;

        public int damage = 10;
        public float speed = 20;

        public Pistol(Character user) : base(3, user) {}

        public override void UsePrimary() {

            if (Cooldown() > 0) return;

            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(character.controller.facingRight && worldPoint.x > projSrc.transform.position.x)
            {
                projSrc.Shoot(Vector3.Normalize(new Vector3(worldPoint.x - projSrc.transform.position.x, worldPoint.y - projSrc.transform.position.y, 0)), speed, damage);
                StartCooldown();
            }
            else if (!character.controller.facingRight && worldPoint.x < projSrc.transform.position.x)
            {
                projSrc.Shoot(Vector3.Normalize(new Vector3(worldPoint.x - projSrc.transform.position.x, worldPoint.y - projSrc.transform.position.y, 0)), speed, damage);
                StartCooldown();
            }

        }

        public override void UseSecondary() {}

        public override void ActivatePassive() {
            projSrc = character.projectileOutput.AddComponent<ProjectileSource>();
            projSrc.colliders = new Collider2D[]{ character.GetComponent<Collider2D>()};
            projSrc.projectileObject = Resources.Load<GameObject>("Prefabs/Bullet/Bullet");
        }
        public override void UsePassive() {}
        public override void RevertPassive() {
            UnityEngine.Object.Destroy(projSrc);
        }
    }
}