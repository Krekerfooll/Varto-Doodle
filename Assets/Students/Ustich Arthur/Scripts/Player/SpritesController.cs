using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class SpritesController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _playerSpriteRenderer;
        [SerializeField] private SpriteRenderer _shadowSpriteRenderer;

        [SerializeField] private PlayerMovement _playerMovement;

        private void Update()
        {
            ManageSprites();
        }


        private void ManageSprites()
        {
            _shadowSpriteRenderer.enabled = _playerMovement.IsGrounded ? true : false;

            if (_playerMovement.MoveDirection > 0)
                _playerSpriteRenderer.flipX = true;
            else if (_playerMovement.MoveDirection < 0)
                _playerSpriteRenderer.flipX = false;
        }
    }
}
