using System.Collections;
using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Player
{
    public class BuffSpring : BuffBase
    {
        [SerializeField] private float _jumpIncreaseAmount;
        [SerializeField] private float _powerupDuration;
        [SerializeField] private string _onTriggerEnterWithTag;
        [SerializeField] private Transform _targetPlayer;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private GameObject _spriteIdle;
        [SerializeField] private GameObject _spriteActivated;
        [SerializeField] private Collider2D _colliderToDisable;

        private bool _buffOver;



        protected override bool IsCanBeBuffed()
        {
            return _targetPlayer.position.y > transform.position.y;
        }

        protected override bool IsBuffOver()
        {
            return _buffOver;
        }

        protected override void ApplyBuff()
        {
            _playerController.SetJumpPower(_jumpIncreaseAmount);
        }

        protected override void RemoveBuff()
        {
            _spriteIdle.SetActive(true);
            _spriteActivated.SetActive(false);
            _playerController.SetJumpPower(-_jumpIncreaseAmount);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            if (other.CompareTag($"{_onTriggerEnterWithTag}"))
            {
                StartCoroutine(PowerupSequence(playerController));
            }
        }
        
        private IEnumerator PowerupSequence(PlayerController playerController)
        {
            _spriteIdle.SetActive(false);
            _spriteActivated.SetActive(true);
            
            //activate
            ActivatePowerup(playerController);
            
            //wait
            yield return new WaitForSeconds(_powerupDuration);
            
            //deactivate
            DeactivatePowerup(playerController);
            
            //sprite
            _spriteIdle.SetActive(true);
            _spriteActivated.SetActive(false);
            
        }
        private void ActivatePowerup(PlayerController playerController)
        {
            playerController.SetJumpPower(_jumpIncreaseAmount);
        }
        private void DeactivatePowerup(PlayerController playerController)
        {
            playerController.SetJumpPower(-_jumpIncreaseAmount);
        }
        
    }
}
