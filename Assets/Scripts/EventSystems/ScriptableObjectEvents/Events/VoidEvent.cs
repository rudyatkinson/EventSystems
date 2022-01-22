using UnityEngine;

namespace BilalAydin.ScriptableObject.Events
{
    [CreateAssetMenu(
        fileName = "NewVoidEvent", 
        menuName = "Scriptable Object Events/Void Event", 
        order = 0)]
    public class VoidEvent : BaseEvent<Void>
    {
        public void Invoke() => Invoke(new Void());
    }
}