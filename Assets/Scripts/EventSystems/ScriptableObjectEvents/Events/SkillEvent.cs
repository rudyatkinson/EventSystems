using UnityEngine;

namespace BilalAydin.ScriptableObject.Events
{
    [CreateAssetMenu(
        fileName = "NewSkillEvent", 
        menuName = "Scriptable Object Events/Skill Event", 
        order = 2)]
    public class SkillEvent : BaseEvent<Character.Skill> { }
}