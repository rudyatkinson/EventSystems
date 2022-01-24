using UnityEngine;
using UnityEngine.Events;

namespace BilalAydin.EventSystems.Observer.ClassicalApproach
{
    public class PressSpaceAchievement_ClassicalApproach : Subject
    {
        [SerializeField] private string achievementName;
        
        public bool KeyDown => Input.GetKeyDown(KeyCode.A);

        private void Update()
        {
            if (KeyDown)
            {
                Invoke(achievementName);
                enabled = false;
            }
        }
    }
}