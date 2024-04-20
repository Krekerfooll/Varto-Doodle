using UnityEngine;
using Students.Shupa_Dubrova_Artem.Scripts.Utils;

namespace Students.Shupa_Dubrova_Artem.Scripts.Platforms
{
    public class DestroyablePlatfrom : OnCollisionAction
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _delay;

        protected override void Execute()
        {
            DestroyPlatform();
        }

        private void DestroyPlatform()
        {
            Destroy(_gameObject, _delay);
            if (_animator != null)
            {
                _animator.SetBool("isDestroyed", true);
            }
        }
    }
}