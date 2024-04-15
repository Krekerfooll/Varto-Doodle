using System.Collections.Generic;
using UnityEngine;

namespace PVitaliy.Actions.Core
{
    public class ActionExecutor : ActionExecutorBase
    {
        [SerializeField] protected List<ActionBase> actions;

        public void Execute()
        {
            if (_executeOnce && _executedOnce) return;
            ExecuteActions(actions);
        }
    }
}