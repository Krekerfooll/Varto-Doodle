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
            if (_playerMovement.IsGrounded)
                _shadowSpriteRenderer.enabled = true;
            else
                _shadowSpriteRenderer.enabled = false;

            if (_playerMovement.MoveDirection > 0)
                _playerSpriteRenderer.flipX = true;
            else if (_playerMovement.MoveDirection < 0)
                _playerSpriteRenderer.flipX = false;
        }
    }
}
