using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Artur.Pashchenko.Platform
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _collider;
        protected bool _enabled;

        public void Init (Transform target) 
        {
            _target = target;
            _enabled = true;
        }
        private void Update()
        {
            if (_enabled)
            {
                UpdatePlatformCollider();
            }
        }

        protected virtual void UpdatePlatformCollider() 
        { 
            if (transform.position.y < _target.transform.position.y) 
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