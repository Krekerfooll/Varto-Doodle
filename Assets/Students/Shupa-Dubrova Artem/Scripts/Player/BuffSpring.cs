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
        [SerializeField] private Collider2D _colliderToDisable;

        private PlayerController _playerController;
        private bool _canBeBuffed;
        private bool _buffIsOver;
        
        protected override bool IsCanBeBuffed()
        {
            return _canBeBuffed;
        }

        protected override bool IsBuffOver()
        {
            return _buffIsOver;
        }

        protected override void ApplyBuff()
        {
            _playerController.SetJumpPower(_jumpBuffAmount);
            StartCoroutine(BuffSequence());
        }

        protected override void RemoveBuff()
        {
            _playerController.SetJumpPower(0);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            _playerController = other.gameObject.GetComponent<PlayerController>();
            if (other.CompareTag($"{_onTriggerEnterWithTag}"))
            {
                _canBeBuffed = true;
            }
        }
        
        private IEnumerator BuffSequence()
        {

            _canBeBuffed = false;
            _buffIsOver = false;
            
            _spriteIdle.SetActive(false);
            _spriteActivated.SetActive(true);
            
            yield return new WaitForSeconds(_powerupDuration);
            
            _spriteIdle.SetActive(true);
            _spriteActivated.SetActive(false);

            _buffIsOver = true;
        }
    }
}
