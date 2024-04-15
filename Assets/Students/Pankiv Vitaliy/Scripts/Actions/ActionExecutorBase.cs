using System.Collections.Generic;
using UnityEngine;

namespace PVitaliy.Actions.Core
{
    public class ActionExecutorBase : MonoBehaviour
    {
        [SerializeField] protected bool _executeOnce;
        protected bool _executedOnce;
        protected void ExecuteActions(IEnumerable<ActionBase> actions)
        {
            if (_executedOnce && _executeOnce) return;
            _executedOnce = true;
            foreach (var action in actions)
            {
                action.Execute();
            }
        }
    }
}