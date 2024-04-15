using UnityEngine;
using Students.Shupa_Dubrova_Artem.Scripts.Objects;

namespace Students.Shupa_Dubrova_Artem.Scripts.Platforms
{
    public class DestroyablePlatfrom : OnCollisionEvents
    {
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _delay;
        
        protected override void ExecuteInternal()
        {
            DestroyPlatform();
        }

        private void DestroyPlatform()
        {
            Destroy(_gameObject, _delay);
            if (_animator is not null)
            {
                _animator.SetBool("isDestroyed", true);
            }
        }
        
    }
}