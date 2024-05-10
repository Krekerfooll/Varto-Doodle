using System.Collections;
using Students.Shupa_Dubrova_Artem.Scripts.Player;
using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Examples
{
    public abstract class OldBuffBase : MonoBehaviour
    {
        [SerializeField] protected string _onTriggerEnterWithTag;
        protected PlayerController _playerController;
        protected bool _buffActive;
        
        protected void OnTriggerEnter2D(Collider2D other)
        {
            _playerController = other.gameObject.GetComponent<PlayerController>();
            if (other.CompareTag($"{_onTriggerEnterWithTag}") && !_buffActive)
            {
                StartCoroutine(BuffSequence(_playerController));
            }
        }

        protected abstract IEnumerator BuffSequence(PlayerController _playerController);
    }
}