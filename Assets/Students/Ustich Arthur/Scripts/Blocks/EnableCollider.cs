using Unity.VisualScripting;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class EnableCollider : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D _boxCollider2D;
        private Transform _targetTransform;
        private float _pivotOffset = 1;
        


        private void Start()
        {
            _targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
            _boxCollider2D.enabled = false;
        }

        private void Update()
        {
            if (_targetTransform != null && _targetTransform.position.y - _pivotOffset >= transform.position.y) 
                _boxCollider2D.enabled = true;
            else
                _boxCollider2D.enabled = false;
        }
    }
}
