using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Events;

namespace PVitaliy.Core
{
    public class GlobalEvents
    {
        private static readonly Dictionary<EventNames, UnityEvent<object>> Events = new Dictionary<EventNames, UnityEvent<object>>();

        public static void AddAction(EventNames eventName, UnityAction<object> action)
        {
            if (!Events.ContainsKey(eventName))
            {
                Events.Add(eventName, new UnityEvent<object>());
            }
            Events[eventName].AddListener(action);
        }

        public static void RemoveAction(EventNames eventName, UnityAction<object> action) // Нехай буде, хоч уже й кінець проекту(
        {
            var eventData = Events[eventName];
            if (eventData.IsUnityNull())
            {
                return;
            }
            eventData.RemoveListener(action);
            if (eventData.GetPersistentEventCount() == 0)
            {
                Events[eventName] = null;
            }
        }
        public static void CallEvent(EventNames eventName, object data = null)
        {
            Events[eventName]?.Invoke(data);
        }
    }
    public enum EventNames
    {
        LevelGeneratorChanged
    }
}