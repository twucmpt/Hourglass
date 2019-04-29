using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Taken from https://unity3d.com/learn/tutorials/topics/2d-game-creation/scripting-gravity?playlist=17093

namespace Hourglass.Physics
{
    public class PhysicsObject : MonoBehaviour
    {

        public float minGroundNormalY = .65f;
        public float gravityModifier = 1f;
        public float fallModifier = 1f;
        public float horizontalModifier = 1f;

        public bool ragdoll = false;
        public bool useNormals = true;

        protected Vector2 targetVelocity;
        protected bool grounded;
        protected Vector2 groundNormal;
        // Physics objects must have a RigidBody2D component set to kinematic.
        protected Rigidbody2D rb;
        protected Vector2 velocity;
        protected ContactFilter2D contactFilter;
        protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
        protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);


        protected const float minMoveDistance = 0.001f;
        protected const float shellRadius = 0.01f;

        void OnEnable()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            contactFilter.useTriggers = false;
            contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
            contactFilter.useLayerMask = true;
        }

        void Update()
        {
            targetVelocity = Vector2.zero;
            if (!ragdoll)
            {
                ComputeVelocity();
            }
        }

        protected virtual void ComputeVelocity()
        {

        }

        void FixedUpdate()
        {
            velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
            if (!ragdoll)
            {
                velocity.x = targetVelocity.x;
            }
            grounded = false;
            //ragdoll = true; //Can't control motion in air

            Vector2 deltaPosition = velocity * Time.deltaTime;

            if (tag == "Player")
            {
                Debug.Log(gravityModifier + " "+ velocity + " " + deltaPosition.x + " " + deltaPosition.y);
            }

            Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

            if (!useNormals)
                moveAlongGround = new Vector2(1, 0);

            Vector2 move = moveAlongGround * deltaPosition.x * horizontalModifier;

            Movement(move, false);

            move = Vector2.up * deltaPosition.y;
            if(deltaPosition.y < 0)
            {
                move = move * fallModifier;
            }

            Movement(move, true);
        }

        void Movement(Vector2 move, bool yMovement)
        {
            float distance = move.magnitude;

            if (distance > minMoveDistance)
            {
                int count = rb.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
                hitBufferList.Clear();
                for (int i = 0; i < count; i++)
                {
                    hitBufferList.Add(hitBuffer[i]);
                }

                for (int i = 0; i < hitBufferList.Count; i++)
                {
                    Vector2 currentNormal = hitBufferList[i].normal;
                    if (currentNormal.y > minGroundNormalY)
                    {
                        grounded = true;
                        ragdoll = false;
                        if (yMovement)
                        {
                            groundNormal = currentNormal;
                            currentNormal.x = 0;
                        }
                    }

                    float projection = Vector2.Dot(velocity, currentNormal);
                    if (projection < 0)
                    {
                        velocity = velocity - projection * currentNormal;
                    }

                    float modifiedDistance = hitBufferList[i].distance - shellRadius;
                    distance = modifiedDistance < distance ? modifiedDistance : distance;
                }


            }

            rb.position = rb.position + move.normalized * distance;
        }

    }
}