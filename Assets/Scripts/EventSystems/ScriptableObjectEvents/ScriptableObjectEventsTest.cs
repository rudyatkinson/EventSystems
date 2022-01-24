using BilalAydin.Character;
using BilalAydin.ScriptableObject.Events;
using UnityEngine;

namespace BilalAydin.EventSystems.ScriptableObjectEvents {
    public class ScriptableObjectEventsTest : MonoBehaviour
    {
        [SerializeField] private VoidEvent onKeypad1Pressed;
        [SerializeField] private StringEvent onKeypad2Pressed;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                onKeypad1Pressed.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                onKeypad2Pressed.Invoke("This is a string parameter");
            }
        }

        public void Log(string message) => Debug.Log(message);
        public void LogSkill(Skill skill) => Debug.Log($"Skill: {skill.SkillName}, Cooldown: {skill.SkillCooldown}");
    }
}
