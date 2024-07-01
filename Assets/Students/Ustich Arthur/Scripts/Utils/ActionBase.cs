using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public abstract class ActionBase : MonoBehaviour
    {
        [SerializeField] protected bool _executeOnAwake;
        public bool ExecuteOnAwake { get { return _executeOnAwake; } set { _executeOnAwake = value; } }

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