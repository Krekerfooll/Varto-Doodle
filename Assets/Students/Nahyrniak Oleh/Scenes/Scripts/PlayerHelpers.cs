using UnityEngine;

namespace Doodle.Core
{
    internal class PlayerHelpers
    {
        internal static bool IsPlayerGrounded(Rigidbody2D rigidbody, Collider2D collider)
        {
            Vector2 rayOrigin = (Vector2)rigidbody.transform.position + Vector2.down * collider.bounds.size.y / 1.95f;
            Vector2 rayDirection = Vector2.down;
            float _groundCheckDistance = 0.02f;

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, _groundCheckDistance);
            Debug.DrawLine(rayOrigin, rayOrigin + rayDirection * _groundCheckDistance, Color.red);

            return hit.collider != null;
        }
    }
}
