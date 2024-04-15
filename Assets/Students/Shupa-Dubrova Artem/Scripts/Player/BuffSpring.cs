using System.Collections;
using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Player
{
    public class BuffSpring : BuffBase
    {
        [SerializeField] private float _jumpBuffAmount;
        [SerializeField] private float _powerupDuration;
        [SerializeField] private string _onTriggerEnterWithTag;
        [SerializeField] private GameObject _spriteIdle;
        [SerializeField] private GameObject _spriteActivated;

        private PlayerController _playerController;
        private bool _buffApplied;

        protected override void ApplyBuff()
        {
            return;
        }

        protected override void RemoveBuff()
        {
            return;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            _playerController = other.gameObject.GetComponent<PlayerController>();
            if (other.CompareTag($"{_onTriggerEnterWithTag}") && !_buffApplied)
            {
                StartCoroutine(BuffSequence(_playerController));
            }
        }
        
        private IEnumerator BuffSequence(PlayerController _playerController)
        {
            _buffApplied = true;
            _spriteIdle.SetActive(false);
            _spriteActivated.SetActive(true);
            
            _playerController.SetJumpPower(_jumpBuffAmount);
            yield return new WaitForSeconds(_powerupDuration);
            _playerController.SetJumpPower(_jumpBuffAmount);
            
            
            _spriteIdle.SetActive(true);
            _spriteActivated.SetActive(false);

            _buffApplied = false;
        }
    }
}
