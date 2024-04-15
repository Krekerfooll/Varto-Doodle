using UnityEngine;

namespace PVitaliy.Actions.Core
{
    public abstract class ActionBase : MonoBehaviour
    {
        public void Execute()
        {
            ExecuteInternal();
        }

        protected abstract void ExecuteInternal();
    }
}