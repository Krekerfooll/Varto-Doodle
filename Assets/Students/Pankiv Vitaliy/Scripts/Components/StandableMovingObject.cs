using System;
using System.Collections.Generic;
using UnityEngine;

namespace PVitaliy.Components
{
    public class StandableMovingObject : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidBody;
        private List<Rigidbody2D> _touchingBodies = new List<Rigidbody2D>();
        private void OnCollisionEnter2D(Collision2D other)
        {
            _touchingBodies.Add(other.rigidbody);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            _touchingBodies.Remove(other.rigidbody);
        }

        private void FixedUpdate()
        {
            foreach (var otherRigidBody in _touchingBodies)
            {
                if (otherRigidBody.velocity.x != 0 || otherRigidBody.velocity.y != 0) continue;
                otherRigidBody.velocity = rigidBody.velocity;
            }
        }
    }
}