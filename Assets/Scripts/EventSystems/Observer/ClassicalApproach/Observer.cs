using UnityEngine;

namespace BilalAydin.EventSystems.Observer.ClassicalApproach {
    public abstract class Observer : MonoBehaviour
    {
        public abstract void OnNotify(object value);
    }
}
