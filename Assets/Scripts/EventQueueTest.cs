using System;
using BilalAydin.EventSystems.EventBus;
using UnityEngine;

namespace BilalAydin
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
                EventBus.Invoke(EventBusType.MessageEvent, new BilalAydin.EventSystems.EventBus.EventArgs()
                {
                    Data = new BilalAydin.EventSystems.EventQueue.MessageData()
                    {
                        Title = $"Header ID: {_sentMessageCount}",
                        Message = $"This message includes details."
                    }
                });
            }
        }
    }
}