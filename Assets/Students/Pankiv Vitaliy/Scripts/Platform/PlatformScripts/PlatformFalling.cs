using PVitaliy.Player;
using UnityEngine;

namespace PVitaliy.Platform
{
    public class PlatformFalling : PlatformBase
    {
        public override PlatformType Type => PlatformType.Falling;
        private bool _isFalling;
        protected override bool ColliderEnabled => _isFalling || base.ColliderEnabled;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!Globals.IsPlayer(other.gameObject)) return;

            var playerController = other.gameObject.GetComponent<PlayerMovement>();
            if (playerController.IsGrounded)
            {
                _isFalling = true;
                spriteColorController.ChangeTargetColor(new Color(1, 0, 0, 0)); // TODO: адекватно переробити, на анімацію
                playerController.AfterLandedOnPlatform(this);
                Destroy(gameObject, .4f);
            }
        }
    }
}