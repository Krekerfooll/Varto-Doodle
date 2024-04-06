using System;
using PVitaliy.Colors;
using PVitaliy.Platform;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PVitaliy.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidBody;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private GameController gameController;
        [SerializeField] private ParticleSystem landingAnimation;
        [SerializeField] private ColorTarget colorChanger;
        [SerializeField] private PlayerView viewController;
        [SerializeField] private float rayCastingOffsetY = 0;
        [SerializeField] private float jumpPower = 7;
        [SerializeField] private float moveSpeed = 1;
        [SerializeField] private float raycastDistance = 1;
        
        private Vector2 _previousVelocity;
        public Vector3 LeftRayStartPoint =>
            rigidBody.transform.position + Vector3.left * transform.localScale.x / 2 + Vector3.up * rayCastingOffsetY;
        public Vector3 RightRayStartPoint =>
            rigidBody.transform.position + Vector3.right * transform.localScale.x / 2 + Vector3.up * rayCastingOffsetY;
        public bool IsGrounded => rigidBody.velocity.y <= 0 &&
            (Physics2D.Raycast(LeftRayStartPoint, Vector2.down, raycastDistance, groundMask) ||
            Physics2D.Raycast(RightRayStartPoint, Vector2.down, raycastDistance, groundMask));
        public float RaycastDistance => raycastDistance;

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
            colorChanger.ChangeTargetColor(Random.ColorHSV(0, 1, 0, 1, .5f, 1));
            
            var main = landingAnimation.main;
            var lowerVelocityY = _previousVelocity.y / 10;
            main.startSpeedMultiplier = lowerVelocityY * lowerVelocityY * 4;
            if (main.startSpeedMultiplier >= .3)
            {
                main.startColor = platform.TargetColor * Color.gray;
                landingAnimation.Emit(Mathf.RoundToInt(-_previousVelocity.y));
            }
        }
    }
}
