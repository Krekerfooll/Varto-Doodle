using System;
using System.Collections;
using UnityEngine;


namespace Students.Shupa_Dubrova_Artem.Scripts.Player
{
    public class PowerUp : MonoBehaviour
    {
        [SerializeField] private float _jumpIncreaseAmount = 20;
        [SerializeField] private float _powerupDuration = 3;
        
        [SerializeField] private string _onTriggerEnterWith;
        [SerializeField] private bool _buffOnlyOnce;
        [SerializeField] private GameObject _spriteIdle;
        [SerializeField] private GameObject _spriteActivated;
        [SerializeField] private Collider2D _colliderToDisable;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            if (other.CompareTag($"{_onTriggerEnterWith}"))
            {
                StartCoroutine(PowerupSequence(playerController));
            }
        }

        private IEnumerator PowerupSequence(PlayerController playerController)
        {
            //Disable components
            if (_buffOnlyOnce)
            {
                _spriteIdle.SetActive(false);
                _colliderToDisable.enabled = false;
            }
            else
            {
                if (_spriteActivated != null)
                {
                    _spriteIdle.SetActive(false);
                    _spriteActivated.SetActive(true);
                }
            }
            
            //activate
            ActivatePowerup(playerController);
            
            //wait
            yield return new WaitForSeconds(_powerupDuration);
            
            //deactivate
            DeactivatePowerup(playerController);
            
            //sprite
            if (_spriteActivated != null)
            {
                _spriteIdle.SetActive(true);
                _spriteActivated.SetActive(false);
            }
            
            //destroy
            if (_buffOnlyOnce)
            {
                Destroy(gameObject);
            }
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