using Doodle.Utils;
using UnityEngine;

namespace Doodle.Core
{
    public class IsGroundedCondition : Condition
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Collider2D _collider;

        public override bool Check()
        {
            Vector2 rayOrigin = (Vector2)_rigidbody.transform.position + Vector2.down * _collider.bounds.size.y / 1.95f;
            Vector2 rayDirection = Vector2.down;
            float _groundCheckDistance = 0.02f;

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, _groundCheckDistance);
            Debug.DrawLine(rayOrigin, rayOrigin + rayDirection * _groundCheckDistance, Color.red);

            return hit.collider != null;
        }
    }
}
