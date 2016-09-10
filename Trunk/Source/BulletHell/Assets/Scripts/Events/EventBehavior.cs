using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class EventBehavior : MonoBehaviour {

    public string EventId = "";

    public List<Action<string>> EventHandlers = new List<Action<string>>();

    protected void TriggerEvent()
    {
        foreach (var handler in EventHandlers)
        {
            handler(EventId);
        }
    }
}
