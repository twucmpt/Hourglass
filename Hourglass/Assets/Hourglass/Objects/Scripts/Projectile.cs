using Hourglass;
using Hourglass.Characters;
using Hourglass.Physics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public Vector3 direction;
    public float speed = 1;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }


    public void Shoot(Vector3 direction, float speed)
    {
        this.direction = direction;
        this.speed = speed;
        GameManager.LookAt(transform, transform.position + direction);
    }

    public void Shoot(Vector3 direction, float speed, int damage)
    {
        this.damage = damage;
        Shoot(direction, speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(GameManager.IsCharacter(other.gameObject))
        {
            other.gameObject.GetComponent<Character>().Damage(damage);
        }
        Destroy(gameObject);

        
    }
}

