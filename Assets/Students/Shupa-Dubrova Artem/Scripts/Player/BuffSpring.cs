using System.Collections;
using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Player
{
    public class BuffSpring : BuffBase
    {
        [SerializeField] private float _jumpBuffAmount;
        [SerializeField] private float _powerupDuration;
        [SerializeField] private GameObject _spriteIdle;
        [SerializeField] private GameObject _spriteActivated;

        protected override IEnumerator BuffSequence(PlayerController _playerController)
        {
            _buffActive = true;
            _spriteIdle.SetActive(false);
            _spriteActivated.SetActive(true);
            
            _playerController.SetJumpPower(_jumpBuffAmount);
            yield return new WaitForSeconds(_powerupDuration);
            _playerController.SetJumpPower(0);
            
            
            _spriteIdle.SetActive(true);
            _spriteActivated.SetActive(false);
            _buffActive = false;
        }
    }
}
