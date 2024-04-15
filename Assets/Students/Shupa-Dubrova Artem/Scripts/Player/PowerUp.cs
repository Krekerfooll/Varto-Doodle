using System.Collections;
using UnityEngine;


namespace Students.Shupa_Dubrova_Artem.Scripts.Player
{
    public class PowerUp : MonoBehaviour
    {
        [SerializeField] private float _jumpIncreaseAmount;
        [SerializeField] private float _powerupDuration;
        
        [SerializeField] private string _onTriggerEnterWithTag;
        [SerializeField] private bool _buffOnlyOnce;
        [SerializeField] private GameObject _spriteIdle;
        [SerializeField] private GameObject _spriteActivated;
        [SerializeField] private Collider2D _colliderToDisable;

        private bool _canBeBuffed = true;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            if (other.CompareTag($"{_onTriggerEnterWithTag}") && _canBeBuffed)
            {
                StartCoroutine(PowerupSequence(playerController));
            }
        }

        private IEnumerator PowerupSequence(PlayerController playerController)
        {
            _canBeBuffed = false;
            //Disable components
            if (_buffOnlyOnce)
            {
                _spriteIdle.SetActive(false);
                _spriteActivated.SetActive(false);
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

            _canBeBuffed = true;
        }

        private void ActivatePowerup(PlayerController playerController)
        {
            playerController.SetJumpPower(_jumpIncreaseAmount);
        }
        private void DeactivatePowerup(PlayerController playerController)
        {
            playerController.SetJumpPower(0);
        }

    }
}