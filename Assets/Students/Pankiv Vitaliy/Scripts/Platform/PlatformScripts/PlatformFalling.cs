using PVitaliy.Player;
using UnityEngine;

namespace PVitaliy.Platform
{
    public class PlatformFalling : PlatformStatic
    {
        public override PlatformType Type => PlatformType.Falling;
        private bool _isFalling;
        protected override bool ColliderEnabled => _isFalling || base.ColliderEnabled;

        protected override void OnPlayerLanded(PlayerMovement player)
        {
            _isFalling = true;
            base.OnPlayerLanded(player);
            spriteColorController.ChangeTargetColor(new Color(1, 0, 0, 0)); // TODO: зробити анімацією
            Destroy(gameObject, .4f);
        }
    }
}