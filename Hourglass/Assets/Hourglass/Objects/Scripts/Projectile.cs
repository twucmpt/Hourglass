using Hourglass;
using Hourglass.Characters;
using Hourglass.Physics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public Vector3 direction;
    public float speed = 1;

    protected Rigidbody2D rb;
    protected ProjectileSource source;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected void FixedUpdate()
    {
        if (rb != null)
        {
            rb.velocity = direction * speed;
        }
    }

    protected virtual void OnShoot(Vector3 direction, float speed, ProjectileSource source)
    {
    }

    public void Shoot(Vector3 direction, float speed, ProjectileSource source)
    {
        this.direction = direction;
        this.speed = speed;
        this.source = source;
        GameManager.LookAt(transform, transform.position + direction);
        OnShoot(direction, speed, source);
    }

    public void Shoot(Vector3 direction, float speed, int damage, ProjectileSource source)
    {
        this.damage = damage;
        Shoot(direction, speed, source);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Collision(other);

        
    }

    public virtual void Disable()
    {
    }


    protected virtual void Collision(Collider2D other)
    {
        if (GameManager.IsCharacter(other.gameObject))
        {
            other.gameObject.GetComponent<Character>().Damage(damage);
        }

        source.RemoveProjectile(gameObject);
        Destroy(gameObject);
    }
}

