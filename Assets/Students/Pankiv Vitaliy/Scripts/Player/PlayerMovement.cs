using UnityEngine;

namespace PVitaliy.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidBody;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private PlayerView viewController;
        [SerializeField] private float rayCastingOffsetY = 0;
        [SerializeField] private float raycastDistance = 1;
        [SerializeField] private float jumpPower = 7;
        [SerializeField] private float moveSpeed = 1;
        public bool IsGrounded => rigidBody.velocity.y <= 0 && (
            Physics2D.Raycast(GetRayStartPosition(-1), Vector2.down, raycastDistance, groundMask) ||
            Physics2D.Raycast(GetRayStartPosition(1), Vector2.down, raycastDistance, groundMask)
            );
        public float RaycastDistance => raycastDistance;

        public Vector3 GetRayStartPosition(float rayDirectionX = 0)
        {
            return rigidBody.transform.position + Vector3.right * (rayDirectionX * .35f) + Vector3.up * rayCastingOffsetY;
        }

        private void Update()
        {
            UpdateMovement();
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
            {
                JumpAction();
            }
        }

        private void UpdateMovement()
        {
            var x = Input.GetAxisRaw("Horizontal");
            ChangeViewDirection(x);
            rigidBody.velocity = new Vector2(x * moveSpeed, rigidBody.velocity.y);
        }

        private void JumpAction()
        {
            rigidBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        private void FixedUpdate()
        {
            if (rigidBody.velocity.y < -1)
            {
                rigidBody.velocity += Vector2.up * (rigidBody.mass * Physics2D.gravity.y / 50f);
            }
        }

        private void ChangeViewDirection(float directionX)
        {
            if (directionX == 0) return;
            viewController.ChangeDirection(directionX < 0);
        }
    }
}
