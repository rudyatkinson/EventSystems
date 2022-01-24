using System.Collections.Generic;
using UnityEngine;

namespace BilalAydin.EventSystems.Observer.ClassicalApproach {
    public abstract class Subject : MonoBehaviour
    {
        private List<Observer> _observers = new List<Observer>();

        public void Subscribe(Observer observer) => _observers.Add(observer);

        public void Unsubscribe(Observer observer) => _observers.Remove(observer);

        public void Invoke(object value = null)
        {
            _observers.ForEach(item =>
            {
                item.OnNotify(value);
            });
        }
    }
}
