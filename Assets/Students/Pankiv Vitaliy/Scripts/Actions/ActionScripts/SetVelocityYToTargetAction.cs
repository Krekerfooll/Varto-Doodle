using UnityEngine;

namespace PVitaliy.Actions
{
    public class SetVelocityYToTargetAction : ActionBaseWithTarget
    {
        [SerializeField] private float velocityY;
        protected override void ExecuteInternal()
        {
            var rigidBody = Target.GetComponent<Rigidbody2D>();
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, velocityY);
        }
    }
}