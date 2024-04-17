using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_PlayerAnimationManager : MonoBehaviour
    {
        [SerializeField] private OI_GameData gameData;
        [SerializeField] private OI_PlayerJumpAction jumpAction;

        private Vector2 playerVelocity;
        private Animator playerAnimator;

        private void Awake()
        {
            playerAnimator = gameData.playerRenderAnimator;
        }

        private void Update()
        {
            if (gameData.playerInstance != null)
            {
                playerVelocity = gameData.playerRigidBody.velocity;
                CheckPlayerState();
                AnimationSwitch();
            }
        }
        private void CheckPlayerState()
        {
            if (!gameData.playerIsAlive)
            {
                playerAnimator.SetBool("isDying",true);

            }
        }
        private void AnimationSwitch()
        {

            if (playerVelocity.y == 0)
            {
                playerAnimator.SetBool("isJumping", false);
                playerAnimator.SetBool("isFalling", false);
            }
            else if (playerVelocity.y > 0)
            {
                playerAnimator.SetBool("isJumping", true);
                playerAnimator.SetBool("isFalling", false);
            }
            else if (playerVelocity.y < 0)
            {
                playerAnimator.SetBool("isJumping", false);
                playerAnimator.SetBool("isFalling", true);
            }
                


            if (playerVelocity.x > 0.2f || playerVelocity.x < -0.2f)
                playerAnimator.SetBool("isMoving", true);
            else
                playerAnimator.SetBool("isMoving", false);
        }

    }
}