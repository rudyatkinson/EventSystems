using System;
using System.Collections.Generic;
using BilalAydin.ScriptableObject.Listeners;
using UnityEngine;

namespace BilalAydin.ScriptableObject.Events 
{
    public abstract class BaseEvent<T> : UnityEngine.ScriptableObject
    {
        private List<IEventListener<T>> _events = new List<IEventListener<T>>();

        public void Invoke(T param)
        {
            for (int i = _events.Count - 1; i >= 0; i--)
            {
                _events[i].OnEventInvoked(param);
            }
        }

        public void Subscribe(IEventListener<T> listener)
        {
            if (_events.Contains(listener)) return;
            
            _events.Add(listener);
        }

        public void Unsubscribe(IEventListener<T> listener)
        {
            if (!_events.Contains(listener)) return;

            _events.Add(listener);
        }
    }
}
