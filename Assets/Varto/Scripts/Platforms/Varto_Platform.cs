using System;
using System.Collections.Generic;
using UnityEngine;
using Varto.Examples.Utils;

namespace Varto.Examples.Platforms
{
    [System.Serializable]
    public class Varto_Platform : MonoBehaviour
    {
        [SerializeField] protected Transform _target;
        [SerializeField] protected GameObject _collider;
        [Space]
        [Tooltip("Is object stays active after become active ones")]
        [SerializeField] protected bool _staysActive = true;
        [Space]
        [SerializeField] protected List<Varto_ActionBase> _executeOnCollisionActivated;
        [SerializeField] protected List<Varto_ActionBase> _executeOnCollisionDeactivated;

        public bool IsPlatformActivated => _collider != null && _collider.activeSelf;

        protected bool _isInitiated;
        protected bool _isActivatedOnes;

        public void Init(Transform target, bool forceActive = false)
        {
            _target = target;
            _isInitiated = true;

            if (forceActive)
            {
                _collider.SetActive(true);
                _isActivatedOnes = true;

                foreach (var action in _executeOnCollisionActivated)
                    action.Execute();
            }
        }

        void Update()
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

            if (_target == null)
                return;

            if (_target.transform.position.y > transform.position.y)
            {
                _collider.SetActive(true);
                _isActivatedOnes = true;

                foreach (var action in _executeOnCollisionActivated)
                    action.Execute();
            }
            else
            {
                _collider.SetActive(false);

                foreach (var action in _executeOnCollisionDeactivated)
                    action.Execute();
            }
        }
    }
}
