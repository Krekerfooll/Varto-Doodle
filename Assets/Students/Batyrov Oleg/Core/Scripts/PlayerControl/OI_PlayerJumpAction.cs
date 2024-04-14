using UnityEngine;
namespace OIMOD.Core.Component
{
    public class OI_PlayerJumpAction : OI_ActionBase
    {
        [SerializeField] private OI_InputManager inputManager;
        [SerializeField] private OI_GameData gameData;
        private bool _canJump;
        private bool _activateAutoJump;
        private bool _autoJumpOn;

        private void Awake()
        {
            _autoJumpOn = gameData.playerAutoJump;
        }

        private void Update()
        {
            RayCheckGround();
            AnimationSwitch();
            if (_autoJumpOn && _activateAutoJump)
                CheckJump();
        }
        protected override void ExecuteInternal()
        {
            if (_autoJumpOn && !_activateAutoJump)
                _activateAutoJump = true;
            else if (_autoJumpOn && _activateAutoJump)
                _activateAutoJump = false;
            if (!_autoJumpOn)
                CheckJump();
        }
        private void RayCheckGround()
        {
            var rayPosLeft = gameData.rayPosLeft.transform.position;
            var rayPosCenter = gameData.rayPosCenter.transform.position;
            var rayPosRight = gameData.rayPosRight.transform.position;
            var _jumpRayDist = gameData.jumpRayDist;
            var _layerMask = gameData.layerMask;

            RaycastHit2D hitGroundLeft = Physics2D.Raycast(rayPosLeft, Vector2.down, _jumpRayDist, _layerMask);
            RaycastHit2D hitGroundCenter = Physics2D.Raycast(rayPosCenter, Vector2.down, _jumpRayDist, _layerMask);
            RaycastHit2D hitGroundRight = Physics2D.Raycast(rayPosRight, Vector2.down, _jumpRayDist, _layerMask);

            Debug.DrawRay(rayPosLeft, Vector2.down * hitGroundLeft.distance, Color.green);
            Debug.DrawRay(rayPosCenter, Vector2.down * hitGroundCenter.distance, Color.red);
            Debug.DrawRay(rayPosRight, Vector2.down * hitGroundRight.distance, Color.blue);

            if (hitGroundLeft.collider || hitGroundRight.collider || hitGroundCenter.collider)
                _canJump = true;
            else
                _canJump = false;
        }
        private void CheckJump()
        {
            var playerRbVelocity = gameData.playerRigidBody.velocity;

            if (_canJump && !_autoJumpOn && (playerRbVelocity.y <= 0)) Jump();
            else if (_autoJumpOn && _activateAutoJump && _canJump && (playerRbVelocity.y <= 0)) Jump();
        }
        private void Jump()
        {
            var playerRb = gameData.playerRigidBody;
            var _jumpPower = gameData.playerJumpForce;

            playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
            playerRb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _canJump = false;
        }
        private void AnimationSwitch()
        {
            var playerRbVelocityY = gameData.playerRigidBody.velocity.y;
            var playerAnimator = gameData.playerRenderAnimator;

            if (_canJump && playerRbVelocityY == 0)
                playerAnimator.SetBool("InAir", false);
            else if (!_canJump && playerRbVelocityY != 0)
                playerAnimator.SetBool("InAir", true);
        }
    }
}

