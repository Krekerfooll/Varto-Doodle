using System;
using UnityEngine;

namespace Examples.Player
{
    public static class GlobalEventSender
    {
        public static Action<string> OnEvent;

        public static void FireEvent(string eventName)
        {
            OnEvent?.Invoke(eventName);
        }
    }
}