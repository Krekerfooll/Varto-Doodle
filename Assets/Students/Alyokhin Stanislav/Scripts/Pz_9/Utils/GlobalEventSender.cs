using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alokhin.Stanislav.Utils
{
    public class GlobalEventSender : OnCollisionEventsActionBase
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

