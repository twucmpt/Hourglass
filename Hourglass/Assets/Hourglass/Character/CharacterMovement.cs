﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Items;

// Modified from https://unity3d.com/learn/tutorials/topics/2d-game-creation/scripting-gravity?playlist=17093

public class CharacterMovement : PhysicsObject
{
    public float maxLandSpeed = 7;
    public float maxAirSpeed = 3;
    private List<Item> items = new List<Item>();
    public float jumpTakeOffSpeed = 7;
    public bool facingRight = true;
    public float flipSensitivity = 0.01f;

    private float move;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void VelocityOverride(Vector2 v)
    {
        targetVelocity = v;
        velocity = v;
    }

    public Vector2 GetVelocity()
    {
        return velocity;
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

    protected void UpdateVelocity()
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

        if (move.x > flipSensitivity)
        {
            spriteRenderer.flipX = !facingRight;
        }
        else if (move.x < -flipSensitivity)
        {
            spriteRenderer.flipX = facingRight;
        }

        animator.SetBool("Grounded", grounded);
        animator.SetFloat("Speed", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }

    internal bool IsGrounded()
    {
        return grounded;
    }
}