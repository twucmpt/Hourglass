using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSource : MonoBehaviour
{

    public int damage = 0;
    public float speed = 1;
    public GameObject projectileObject;

    public Collider2D[] colliders;

    public void Shoot(Vector3 direction)
    {
        Shoot(direction, speed, damage);
    }

    public void Shoot(Vector3 direction, float speed)
    {
        Shoot(direction, speed, damage);
    }

    public void Shoot(Vector3 direction, float speed, int damage)
    {
        GameObject projectile = GameObject.Instantiate(projectileObject);
        projectile.transform.position = transform.position;
        if(colliders != null)
        {
            foreach(Collider2D c in colliders)
            {
                Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), c);
            }
        }
        projectile.GetComponent<Projectile>().Shoot(direction, speed, damage);
    }
}
