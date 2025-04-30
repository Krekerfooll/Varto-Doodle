using UnityEngine;
using System;

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
