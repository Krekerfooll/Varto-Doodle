using System.Collections.Generic;
using UnityEngine;

namespace PVitaliy.Actions.Core
{
    public class ActionExecutor : ActionExecutorBase
    {
        [SerializeField] protected List<ActionBase> actions;

        public override void Execute()
        {
            if (_executeOnce && _executedOnce) return;
            ExecuteActions(actions);
        }
        
        protected void SetActionsTarget(GameObject target)
        {
            actions.ForEach(action =>
            {
                if (action is ActionBaseWithTarget a) a.SetTarget(target);
            });
        }
    }
}