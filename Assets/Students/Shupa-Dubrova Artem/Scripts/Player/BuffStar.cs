using System.Collections;
using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Player
{
    public class BuffStar : BuffBase
    {
        [SerializeField] private float _jumpBuffAmount;
        [SerializeField] private float _powerupDuration;
        [SerializeField] private string _onTriggerEnterWithTag;
        [SerializeField] private GameObject _spriteToDelete;
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
            _spriteToDelete.SetActive(false);
            _colliderToDisable.enabled = false;
            
            yield return new WaitForSeconds(_powerupDuration);
            
            Destroy(gameObject);

            _buffIsOver = true;
        }
    }
}
