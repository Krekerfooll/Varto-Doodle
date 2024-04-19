using UnityEngine;

namespace Doodle.Core
{
    internal class Platform : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;

        private Transform _target;
        private bool _isInitiated;

        internal void Init(Transform target)
        {
            _target = target;
            _isInitiated = true;
        }
        private void Update()
        {
            if (_isInitiated)
            {
                HandlePlatformPass(_target, _collider);
            }
        }
        private void HandlePlatformPass(Transform target, Collider2D platformCollider)
        {
            platformCollider.enabled = target.transform.position.y > transform.position.y;
        }
    }
}
