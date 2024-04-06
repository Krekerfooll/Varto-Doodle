using PVitaliy.Colors;
using PVitaliy.Player;
using UnityEngine;

namespace PVitaliy.Platform
{
    public class PlatformStatic : PlatformBase
    {
        [SerializeField] private ColorTarget spriteColorController;
        public override PlatformType Type => PlatformType.Static;
        public Color TargetColor => spriteColorController.TargetColor;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.tag.Equals("Player")) return;

            var playerController = other.gameObject.GetComponent<PlayerMovement>(); // Щось ще придумаю (тряска камери?)
            if (playerController.IsGrounded)
            {
                playerController.AfterLandedOnPlatform(this);
            }
        }
    }
}