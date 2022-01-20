using System;
using EventSystems.EventBus;
using UnityEngine;

public class EventQueueTest : MonoBehaviour
{
    private bool _sendMessage => Input.GetKeyDown(KeyCode.Space);

    private int _sentMessageCount = 0;
        
    private void Update()
    {
        if (_sendMessage)
        {
            _sentMessageCount++;
            EventBus.Invoke(EventBusType.MessageEvent, new EventSystems.EventBus.EventArgs()
            {
                Data = new EventSystems.EventQueue.MessageData()
                {
                    Title = $"Header ID: {_sentMessageCount}",
                    Message = $"This message includes details."
                }
            });
        }
    }
}