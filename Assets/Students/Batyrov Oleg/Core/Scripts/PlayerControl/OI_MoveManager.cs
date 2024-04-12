using OIMOD.Core.Component;
using UnityEngine;

namespace OIMOD.Core.GameMech
{
    public class OI_MoveManager : MonoBehaviour
    {
        [SerializeField] private OI_InputManager inputManager;
        [SerializeField] private OI_GameData gameData;

        [SerializeField] private bool _autoJumpOn;
        
        private bool _canJump;
        private bool _activateAutoJump;

        private void Update() 
        {
            if (inputManager.JumpInput) 
                _activateAutoJump = true;
            RayCheckGround();
            BorderCheck();
            CheckJump();
        }
        private void FixedUpdate() 
        { 
            Move(); 
            SpeedLimit();
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

            var playerRbVelocityY = gameData.playerRigidBody.velocity.y;
            var playerAnimator = gameData.playerRenderAnimator;

            if (hitGroundLeft.collider || hitGroundRight.collider || hitGroundCenter.collider) 
            {
                _canJump = true;
                if (playerRbVelocityY == 0)
                    playerAnimator.SetBool("InAir", false);
            }
            else 
            {
                _canJump = false;
                if (playerRbVelocityY != 0)
                    playerAnimator.SetBool("InAir", true);
            }
        }
        private void CheckJump() 
        {
            var _autoJumpOn = gameData.playerAutoJump;
            var playerRbVelocity = gameData.playerRigidBody.velocity;

            if (_canJump && inputManager.JumpInput && !_autoJumpOn && (playerRbVelocity.y <= 0)) Jump();
            else if (_autoJumpOn && _activateAutoJump && _canJump && (playerRbVelocity.y <= 0)) Jump();
        }
        private void Jump()
        {
            var playerRb = gameData.playerRigidBody;
            var _jumpPower = gameData.playerJumpForce;

            playerRb.velocity = new Vector2(playerRb.velocity.x,0);
            playerRb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _canJump = false;
        }
        private void Move() 
        {
            var playerRb = gameData.playerRigidBody;
            var _speed = gameData.playerSpeed;
            var playerRender = gameData.playerRender.transform;

            playerRb.velocity = new Vector2(inputManager.MoveInput * _speed, playerRb.velocity.y);
            if (inputManager.MoveInput > 0) playerRender.localScale = new Vector3(-1,1,1);
            else if (inputManager.MoveInput < 0) playerRender.localScale = new Vector3(1,1,1);
        }
        private void BorderCheck() 
        {
            var playerTransform = gameData.playerInstance.transform;
            var playerPos = gameData.playerInstance.transform.position;
            var borderLeft = gameData.levelBorderLeft.transform.position.x;
            var borderRight = gameData.levelBorderRight.transform.position.x;

            if (playerPos.x < borderLeft)
                playerTransform.position = new Vector3(borderRight, playerPos.y, 0);
            else if (playerPos.x > borderRight)
                playerTransform.position = new Vector3(borderLeft, playerPos.y, 0);
        }
        private void SpeedLimit() 
        {
            var playerRb = gameData.playerRigidBody;
            var _maxVelocity = gameData.playerMaxVelocity;
            playerRb.velocity = Vector2.ClampMagnitude(gameData.playerRigidBody.velocity, _maxVelocity);
        } 
    }
}

