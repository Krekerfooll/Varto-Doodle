using Artur.Pashchenko.Utils;
using System.Collections.Generic;
using UnityEngine;
namespace Artur.Pashchenko.Platform
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _collider;
        [SerializeField] protected bool _staysActive = true;
        protected bool _enabled;
        [SerializeField] protected List<ActionBase> _doOnCollisionActivated;
        [SerializeField] protected List<ActionBase> _doOnCollisionDeactivated;

       
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
            if (_target.transform.position.y > transform.position.y)
            {
                _collider.SetActive(true);
                foreach (var action in _doOnCollisionActivated)
                    action.Execute();

            }
            else
            {
                _collider.SetActive(false);
                foreach (var action in _doOnCollisionDeactivated)
                    action.Execute();

            }
        }
    }
}