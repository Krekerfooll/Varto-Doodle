using PVitaliy.Actions.Core;
using UnityEngine;
using UnityEngine.Events;

namespace PVitaliy.Actions
{
    public class CustomEventsExecutorAction : ActionBase
    {
        [SerializeField] private UnityEvent events;
        protected override void ExecuteInternal()
        {
            events.Invoke();
        }
    }
}