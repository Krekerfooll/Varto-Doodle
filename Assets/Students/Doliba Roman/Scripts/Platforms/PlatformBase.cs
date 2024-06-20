using UnityEngine;

namespace RomanDoliba.Platform
{
    [System.Serializable]
    public class PlatformBase : MonoBehaviour
    {
        [SerializeField] protected Transform _platformTarget;
        [SerializeField] protected GameObject _collider;
        public bool IsPlatformActivated => _collider.activeSelf;
        protected bool _isInitiated;
        protected bool _isActivatedOnes;

        public void Init(Transform target, bool forceActive = false)
        {
            _platformTarget = target;
            _isInitiated = true;

            if (forceActive)
            {
                _collider.SetActive(true);
                _isActivatedOnes = true;
            }
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
            if (_isActivatedOnes || _platformTarget == null)
                return;

            if(_platformTarget.transform.position.y > transform.position.y)
            {
                _collider.SetActive(true);
                _isActivatedOnes = true;
            }
            else
            {
                _collider.SetActive(false);
            }
        }

    }
    
}
