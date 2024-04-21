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

            if (playerVelocity.y > 0.1f)
            {
                playerAnimator.SetBool("isJumping", true);
                playerAnimator.SetBool("isFalling", false);
            }
            else if (playerVelocity.y < -0.1f)
            {
                playerAnimator.SetBool("isJumping", false);
                playerAnimator.SetBool("isFalling", true);
            }
            else
            {
                playerAnimator.SetBool("isJumping", false);
                playerAnimator.SetBool("isFalling", false);
            }
                


            if (playerVelocity.x > 0.1f || playerVelocity.x < -0.1f)
                playerAnimator.SetBool("isMoving", true);
            else
                playerAnimator.SetBool("isMoving", false);
        }

    }
}