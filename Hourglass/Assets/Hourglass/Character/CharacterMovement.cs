using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Modified from https://unity3d.com/learn/tutorials/topics/2d-game-creation/scripting-gravity?playlist=17093

public class CharacterMovement : PhysicsObject
{

    public float maxLandSpeed = 7;
    public float maxAirSpeed = 3;
    public float jumpTakeOffSpeed = 7;

    private float move;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void Jump()
    {
        if (grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
    }

    public void Move(float value)
    {
        move = value;
    }

    public void UpdateVelocity()
    {
        float maxSpeed = 0;
        if (grounded)
        {
            maxSpeed = maxLandSpeed;
        }
        else
        {
            maxSpeed = maxAirSpeed;
        }

        Vector2 move = Vector2.zero;

        move.x = this.move;

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("Grounded", grounded);
        animator.SetFloat("Speed", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}