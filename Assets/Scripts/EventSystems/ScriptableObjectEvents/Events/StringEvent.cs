using UnityEngine;

namespace BilalAydin.ScriptableObject.Events
{
    [CreateAssetMenu(
        fileName = "NewStringEvent", 
        menuName = "Scriptable Object Events/String Event", 
        order = 1)]
    public class StringEvent : BaseEvent<string> { }
}