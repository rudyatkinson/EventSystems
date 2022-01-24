using BilalAydin.EventSystems.EventBus;
using UnityEngine;

namespace BilalAydin.EventSystems.EventQueue
{
    public class EventQueueTest : MonoBehaviour
    {
        private bool _sendMessage => Input.GetKeyDown(KeyCode.Space);

        private int _sentMessageCount = 0;
        
        private void Update()
        {
            if (_sendMessage)
            {
                _sentMessageCount++;
                Bus.Invoke(EventBusType.MessageEvent, new EventArgs()
                {
                    Data = new MessageData()
                    {
                        Title = $"Header ID: {_sentMessageCount}",
                        Message = $"This message includes details."
                    }
                });
            }
        }
    }
}