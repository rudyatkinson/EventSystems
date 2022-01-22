using System;
using BilalAydin.EventSystems;
using BilalAydin.EventSystems.EventBus;
using UnityEngine;
using EventArgs = BilalAydin.EventSystems.EventBus.EventArgs;

namespace BilalAydin
{
    public class EventBusTest : MonoBehaviour
    {
        public int callTimes;
    
        private void Start()
        {
            for (var i = 0; i < callTimes; i++)
            {
                var i1 = i + 1;
                EventBus.Subscribe(EventBusType.StandardEvent, () =>
                {
                    Debug.Log($"{EventBusType.StandardEvent} invoked {i1} times.");
                });
            }

            for (var i = 0; i < callTimes; i++)
            {
                var i1 = i + 1;
                EventBus.Subscribe(EventBusType.AnotherEvent, () =>
                {
                    Debug.Log($"{EventBusType.AnotherEvent} invoked {i1} times.");
                });
            }
            EventBus.Subscribe(EventBusType.AnotherEvent, OnAnotherEventInvoked);

            EventBus.Invoke(EventBusType.StandardEvent);
            EventBus.Invoke(EventBusType.AnotherEvent, new EventArgs()
            {
                Data = new AnotherEventData()
                {
                    Message = "AnotherEvent invoked with parameter."
                }
            });
        }

        private void OnAnotherEventInvoked(EventArgs e)
        {
            AnotherEventData data = (AnotherEventData) e.Data;
            Debug.Log(data.Message);
        }
    }
}