using System.Collections.Generic;
using UnityEngine.Events;

namespace BilalAydin.EventSystems.EventBus
{
    public static class Bus
    {
        private static readonly Dictionary<EventBusType, UnityEvent> Events = new Dictionary<EventBusType, UnityEvent>();

        private static readonly Dictionary<EventBusType, UnityEvent<EventArgs>> EventsWithParameters =
            new Dictionary<EventBusType, UnityEvent<EventArgs>>();

        public static void Subscribe(EventBusType eventType, UnityAction listener)
        {
            if (Events.TryGetValue(eventType, out var @event))
            {
                @event.AddListener(listener);
            }
            else
            {
                UnityEvent newEvent = new UnityEvent();
                newEvent.AddListener(listener);
                Events.Add(eventType, newEvent);
            }
        }

        public static void Subscribe(EventBusType eventType, UnityAction<EventArgs> listener)
        {
            if (EventsWithParameters.TryGetValue(eventType, out var @event))
            {
                @event.AddListener(listener);
            }
            else
            {
                UnityEvent<EventArgs> newEvent = new UnityEvent<EventArgs>();
                newEvent.AddListener(listener);
                EventsWithParameters.Add(eventType, newEvent);
            }
        }

        public static void Unsubscribe(EventBusType eventType, UnityAction listener)
        {
            if (Events.TryGetValue(eventType, out var @event))
            {
                @event.RemoveListener(listener);
            }
        }

        public static void Unsubscribe(EventBusType eventType, UnityAction<EventArgs> listener)
        {
            if (EventsWithParameters.TryGetValue(eventType, out var @event))
            {
                @event.RemoveListener(listener);
            }
        }

        public static void Invoke(EventBusType eventType, EventArgs eventArgs = null)
        {
            if (Events.TryGetValue(eventType, out var @event))
            {
                @event?.Invoke();
            }

            if (eventArgs != null &&
                EventsWithParameters.TryGetValue(eventType, out var @eventWithParams))
            {
                @eventWithParams.Invoke(eventArgs);
            }
        }
    }
}
