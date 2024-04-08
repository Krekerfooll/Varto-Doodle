using PVitaliy.Platform;
using UnityEngine;

namespace PVitaliy.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidBody;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private GameController gameController;
        [SerializeField] private PlayerView viewController;
        [SerializeField] private float rayCastingOffsetY = 0;
        [SerializeField] private float raycastDistance = 1;
        [SerializeField] private float jumpPower = 7;
        [SerializeField] private float moveSpeed = 1;
        
        private Vector2 _previousVelocity;
        public bool IsGrounded => rigidBody.velocity.y <= 0 && (
            Physics2D.Raycast(GetRayStartPosition(-1), Vector2.down, raycastDistance, groundMask) ||
            Physics2D.Raycast(GetRayStartPosition(1), Vector2.down, raycastDistance, groundMask)
            );
        public float RaycastDistance => raycastDistance;

        public Vector3 GetRayStartPosition(float rayDirectionX = 0)
        {
            return rigidBody.transform.position + Vector3.right * rayDirectionX * transform.localScale.x / 2 + Vector3.up * rayCastingOffsetY;
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
            float x = 0;
            if (Input.GetKey(KeyCode.A)) x = -1;
            else if (Input.GetKey(KeyCode.D)) x = 1;
            ChangeViewDirection(x);
            rigidBody.velocity = new Vector2(x * moveSpeed, rigidBody.velocity.y);
        }

        private void JumpAction()
        {
            rigidBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        private void FixedUpdate()
        {
            if (rigidBody.velocity.y < 0)
            {
                rigidBody.velocity += Vector2.up * (rigidBody.mass * Physics2D.gravity.y / 100f);
            }
            _previousVelocity = rigidBody.velocity;
        }

        private void ChangeViewDirection(float directionX)
        {
            if (directionX == 0) return;
            viewController.ChangeDirection(directionX < 0);
        }

        public void AfterLandedOnPlatform(PlatformBase platform)
        {
            viewController.ChangeColor();
            if (!platform.EmitParticlesOnLanding) return;
            viewController.EmitLandingParticles(_previousVelocity.y, platform.TargetColor);
        }
    }
}
