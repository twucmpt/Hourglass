using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSource : MonoBehaviour
{

    public int damage = 0;
    public float speed = 1;
    public GameObject projectileObject;

    public GameObject output;
    public Collider2D[] colliders;
    public List<GameObject> projectiles = new List<GameObject>();

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
        projectile.transform.position = output.transform.position;
        if(colliders != null)
        {
            foreach(Collider2D c in colliders)
            {
                Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), c);
            }
        }
        projectile.GetComponent<Projectile>().Shoot(direction, speed, damage, this);
        projectiles.Add(projectile);
    }

    public void Disable()
    {
        foreach(GameObject proj in projectiles)
        {
            proj.GetComponent<Projectile>().Disable();
        }
    }

    public void RemoveAllProjectiles()
    {
        while(projectiles.Count != 0)
        {
            GameObject proj = projectiles[0];
            proj.GetComponent<Projectile>().Disable();
            projectiles.RemoveAt(0);
            Destroy(proj);
        }
    }

    public void RemoveProjectile(GameObject o)
    {
        projectiles.Remove(o);
    }
}
