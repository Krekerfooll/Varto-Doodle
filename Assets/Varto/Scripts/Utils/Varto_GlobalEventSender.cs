using System;
using UnityEngine;

namespace Varto.Examples.Utils
{
    public class Varto_GlobalEventSender : Varto_OnCollisionEventsActionBase
    {
        public static Action<string> OnEvent;

        [SerializeField] private string _eventName;

        public static void FireEvent(string eventName)
        {
            OnEvent?.Invoke(eventName);
        }

        protected override void ExecuteInternal()
        {
            FireEvent(_eventName);
        }
    }
}