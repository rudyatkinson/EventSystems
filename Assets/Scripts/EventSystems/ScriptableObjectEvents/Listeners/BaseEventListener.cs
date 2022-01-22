﻿using System;
using BilalAydin.ScriptableObject.Events;
using UnityEngine;
using UnityEngine.Events;

namespace BilalAydin.ScriptableObject.Listeners
{
    public class BaseEventListener<T, TE, TEur> : MonoBehaviour, IEventListener<T> 
        where TE : BaseEvent<T> 
        where TEur : UnityEvent<T>
    {
        [SerializeField] private TE @event;
        public TE Event
        {
            get => @event;
            set => @event = value;
        }

        [SerializeField] private TEur response;

        private void OnEnable()
        {
            if (@event == null) return;
            
            @event.Subscribe(this);
        }

        private void OnDisable()
        {
            if (@event == null) return;
            
            @event.Unsubscribe(this);
        }

        public void OnEventInvoked(T param)
        {
            response?.Invoke(param);
        }
    }
}