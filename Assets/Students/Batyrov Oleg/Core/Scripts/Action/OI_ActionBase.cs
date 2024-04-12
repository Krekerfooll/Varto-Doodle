using UnityEngine;

namespace OIMOD.Core.Component
{
    public abstract class OI_ActionBase : MonoBehaviour
    {
        [SerializeField] protected bool _executeOnAwake;
        [SerializeField] protected bool _executeOnce;

        protected bool _isExecutedOnce;

        private void Awake()
        {
            if (_executeOnAwake)
            {
                _isExecutedOnce = true;
                ExecuteInternal();
            }
        }
        public void Execute()
        {
            if (_executeOnce && _isExecutedOnce)
                return;

            _isExecutedOnce = true;
            ExecuteInternal();
        }
        protected abstract void ExecuteInternal();
    }
}

