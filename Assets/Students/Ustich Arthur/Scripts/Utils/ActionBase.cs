using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public abstract class ActionBase : MonoBehaviour
    {
        [SerializeField] protected bool _executeOnAwake;

        private void Awake()
        {
            if (_executeOnAwake)
            {
                Execute();
            }
        }
        public void Execute()
        {
            ExecuteInternal();
        }

        public abstract void ExecuteInternal();
    }
}