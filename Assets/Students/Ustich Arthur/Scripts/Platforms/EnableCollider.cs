using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class EnableCollider : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D _boxCollider2D;
        [SerializeField] private Transform _targetTransform;
        //private float _pivotOffset = 1;

        public void ColliderInit(Transform target)
        {
            _targetTransform = target;
        }

        private void Start()
        {
            _boxCollider2D.enabled = false;
        }

        private void Update()
        {
            if (_targetTransform != null && _targetTransform.position.y >= transform.position.y) 
                _boxCollider2D.enabled = true;
            else if (_targetTransform != null && _targetTransform.position.y < transform.position.y - 0.3f)
                _boxCollider2D.enabled = false;
        }
    }
}
