using System.Collections.Generic;
using UnityEngine;
using EventBusType = EventSystems.EventBus.EventBusType;
using EventArgs = EventSystems.EventBus.EventArgs;

namespace EventSystems.EventQueue
{
    public class MessageBox : MonoBehaviour
    {
        private bool _isRunning = false;

        [SerializeField] private GameObject messagePanel;
        [SerializeField] private TMPro.TMP_Text messageTitleText;
        [SerializeField] private TMPro.TMP_Text messageText;
        
        private static Queue<MessageData> _messageEvent = new Queue<MessageData>();
        private int _messageDataCount => _messageEvent.Count;

        private void OnEnable()
        {
            EventBus.EventBus.Subscribe(EventBusType.MessageEvent, OnMessageReceived);
        }

        private void OnDisable()
        {
            _messageEvent.Clear();
            
            EventBus.EventBus.Unsubscribe(EventBusType.MessageEvent, OnMessageReceived);
        }

        private void OnMessageReceived(EventArgs e)
        {
            MessageData data = (MessageData) e.Data;
            _messageEvent.Enqueue(data);
            
            #if UNITY_EDITOR
            Debug.Log($"Message enqueued, number: {_messageDataCount}");
            #endif
            
            if (_isRunning) return;
            ShowMessage();
        }

        public void ShowMessage()
        {
            _isRunning = _messageDataCount > 0;
            messagePanel.SetActive(_isRunning);
            if (!_isRunning) return;
            
            var data = _messageEvent.Dequeue();
            messageTitleText.text = $"{data.Title}";
            messageText.text = $"{data.Message}";
        }
    }
}
