using System;
using UnityEngine;

namespace RomanDoliba.Utils
{
    public class OnTrigerEventSender : OnTriggerAction
    {
        public static Action<string> OnEvent;
        [SerializeField] private string _eventName;

        public static void FireEvent(string eventName)
        {
            OnEvent?.Invoke(eventName);
        }

        protected override void Execute()
        {
            FireEvent(_eventName);
        }
    }
}