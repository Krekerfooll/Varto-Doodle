using PVitaliy.Actions.Core;
using UnityEngine;
using UnityEngine.Events;

namespace PVitaliy.Actions
{
    public class GameLoseAction : ActionBase
    {
        [SerializeField] private UnityEvent events;
        protected override void ExecuteInternal()
        {
            events.Invoke();
        }
    }
}