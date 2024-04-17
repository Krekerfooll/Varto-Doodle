using System.Collections;
using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Player
{
    public class BuffStar : BuffBase
    {
        [SerializeField] private float _jumpBuffAmount;
        [SerializeField] private float _powerupDuration;
        [SerializeField] private GameObject _spriteToDelete;
        [SerializeField] private Collider2D _colliderToDisable;

        protected override IEnumerator BuffSequence(PlayerController _playerController)
        {
            _buffActive = true;
            _spriteToDelete.SetActive(false);
            _colliderToDisable.enabled = false;
            
            _playerController.SetJumpPower(_jumpBuffAmount);
            yield return new WaitForSeconds(_powerupDuration);
            _playerController.SetJumpPower(0);
            
            _buffActive = false;
            Destroy(gameObject);
        }
    }
}
