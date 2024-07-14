using UnityEngine;

namespace Stanislav.Alokhin.Utils
{
    public abstract class ActionBase : MonoBehaviour
    {
        [SerializeField] protected bool _excuteOnAwake;
        [SerializeField] protected bool _excuteOnlyOnes;

        protected bool _isExecutedOnes;

        private void Awake()
        {
            if (_excuteOnAwake)
            {
                _isExecutedOnes = true;
                ExecuteInternal();
            }
        }
        public void Execute()
        {
            if (_excuteOnlyOnes && _isExecutedOnes)
                return;

            _isExecutedOnes = true;

            ExecuteInternal();
        }
        protected abstract void ExecuteInternal();
    }
}

