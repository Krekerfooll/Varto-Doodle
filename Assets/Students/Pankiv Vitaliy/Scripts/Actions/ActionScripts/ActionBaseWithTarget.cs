using PVitaliy.Actions.Core;
using UnityEngine;

namespace PVitaliy.Actions
{
    public abstract class ActionBaseWithTarget : ActionBase
    {
        protected GameObject Target;

        public void SetTarget(GameObject target)
        {
            Target = target;
        }
    }
}