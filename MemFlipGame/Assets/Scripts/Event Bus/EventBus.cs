using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// interface used for updating the event bus
public interface IEventBus_Connector
{
    void InitEventBus(IEventBus eventBus);
}

public interface IEventBus
{
    void Publish<TEvent>(TEvent evt);
    void Subscribe<TEvent>(Action<TEvent> listener);
    void Unsubscribe<TEvent>(Action<TEvent> listener);
}

public class EventBus : IEventBus
{
    private readonly Dictionary<Type, List<Delegate>> _subscribers = new();

    public void Publish<TEvent>(TEvent evt)
    {
        if (_subscribers.TryGetValue(typeof(TEvent), out var listeners))
            foreach (var listener in listeners)
                (listener as Action<TEvent>)?.Invoke(evt);
    }

    public void Subscribe<TEvent>(Action<TEvent> listener)
    {
        if (!_subscribers.ContainsKey(typeof(TEvent)))
            _subscribers[typeof(TEvent)] = new List<Delegate>();
        _subscribers[typeof(TEvent)].Add(listener);
    }

    public void Unsubscribe<TEvent>(Action<TEvent> listener)
    {
        if (_subscribers.TryGetValue(typeof(TEvent), out var listeners))
            listeners.Remove(listener);
    }
}