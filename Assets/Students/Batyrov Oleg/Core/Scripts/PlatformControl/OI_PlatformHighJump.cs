using UnityEngine;

namespace OIMOD.Core.GameMech
{
    public class OI_PlatformHighJump : OI_PlatformCore
    {
        public override void CollisionOnCheck() { }
        private void OnTriggerEnter2D(Collider2D playerCollider) {
            if (playerCollider.gameObject.tag == "Player")
                _playerRb.AddForce(Vector2.up * _playerJumpForce, ForceMode2D.Impulse);
        }
    }
}

