using PVitaliy.Player;
using UnityEngine;

namespace PVitaliy.Platform
{
    public class PlatformStatic : PlatformBase
    {
        public override PlatformType Type => PlatformType.Static;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!Globals.IsPlayer(other.gameObject)) return;

            var playerController = other.gameObject.GetComponent<PlayerMovement>(); // Щось ще придумаю (тряска камери?)
            if (playerController.IsGrounded)
            {
                spriteColorController.ChangeTargetColor(Random.ColorHSV(0, 1, .2f, 1, .4f, 1));
                playerController.AfterLandedOnPlatform(this);
            }
        }
    }
}