using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Platforms
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] protected Transform _target;
        [SerializeField] protected GameObject _collider;
        [Space] 
        [SerializeField] protected bool _alwaysActive = false;
        [Tooltip("Is object stays active after become active ones")]
        [SerializeField] protected bool _staysActive = true;
        [Space]

        protected bool _isInitiated;
        protected bool _isActivatedOnes;

        public void Init(Transform target)
        {
            _target = target;
            _isInitiated = true;
        }

        private void Update()
        {
            if (_isInitiated)
            {
                OnUpdatePlatform();
            }
        }

        protected virtual void OnUpdatePlatform()
        {
            if (_staysActive && _isActivatedOnes)
                return;
            
            if (_alwaysActive)
                return;
            
            if (_target.transform.position.y < transform.position.y)
                _collider.SetActive(false);

            if (_target.transform.position.y >= transform.position.y)
            {
                _collider.SetActive(true);
                _isActivatedOnes = true;
            }
            
        }
    }
}
