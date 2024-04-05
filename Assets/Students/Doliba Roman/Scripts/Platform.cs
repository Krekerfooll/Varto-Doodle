using UnityEngine;

namespace RomanDoliba.Platform
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] protected Transform _platformTarget;
        [SerializeField] protected GameObject _collider;
        protected bool _isInitiated;

        public void Init(Transform target)
        {
            _platformTarget = target;
            _isInitiated = true;
        }

        void Update()
        {
            if(_isInitiated)
            {
                OnPlatform();
            }
        }

        protected virtual void OnPlatform()
        {
            if(_platformTarget.transform.position.y > transform.position.y)
            {
                _collider.SetActive(true);
            }
            else
            {
                _collider.SetActive(false);
            }
        }

    }
    
}
