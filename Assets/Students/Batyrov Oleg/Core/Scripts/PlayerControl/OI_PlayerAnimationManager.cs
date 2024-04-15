using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_PlayerAnimationManager : MonoBehaviour
    {
        [SerializeField] private OI_GameData gameData;
        [SerializeField] private OI_PlayerJumpAction jumpAction;

        private Vector2 playerVelocity;
        private Animator playerAnimator;

        private bool isJumping;
        private bool isFalling;
        private bool isWalking;

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

        }
        private void AnimationSwitch()
        {

            if (playerVelocity.y == 0)
                playerAnimator.SetBool("InAir", false);
            else if (playerVelocity.y != 0)
                playerAnimator.SetBool("InAir", true);
        }
    }
}