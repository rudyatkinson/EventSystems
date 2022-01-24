using UnityEngine;

namespace BilalAydin.EventSystems.EventBus
{
    public class EventBusTest : MonoBehaviour
    {
        public int callTimes;
    
        private void Start()
        {
            for (var i = 0; i < callTimes; i++)
            {
                var i1 = i + 1;
                Bus.Subscribe(EventBusType.StandardEvent, () =>
                {
                    Debug.Log($"{EventBusType.StandardEvent} invoked {i1} times.");
                });
            }

            for (var i = 0; i < callTimes; i++)
            {
                var i1 = i + 1;
                Bus.Subscribe(EventBusType.AnotherEvent, () =>
                {
                    Debug.Log($"{EventBusType.AnotherEvent} invoked {i1} times.");
                });
            }
            Bus.Subscribe(EventBusType.AnotherEvent, OnAnotherEventInvoked);

            Bus.Invoke(EventBusType.StandardEvent);
            Bus.Invoke(EventBusType.AnotherEvent, new EventArgs()
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