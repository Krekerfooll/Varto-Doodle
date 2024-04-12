using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_PlayerHighJumpAction : OI_ActionBase
    {
        [SerializeField] public GameObject _player;
        [SerializeField] public int _jumpForce;

        protected override void ExecuteInternal()
        {
            var playerRb = _player.GetComponent<Rigidbody2D>();
            playerRb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
