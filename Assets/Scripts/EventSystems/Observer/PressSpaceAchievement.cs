using System;
using UnityEngine;
using UnityEngine.Events;

namespace BilalAydin.Observer
{
    public class PressSpaceAchievement: MonoBehaviour
    {
        [SerializeField] private string achievementName;
        
        public bool KeyDown => Input.GetKeyDown(KeyCode.A);

        public static UnityEvent<string> OnKeyDown = new UnityEvent<string>();

        private void Update()
        {
            if (KeyDown)
            {
                OnKeyDown?.Invoke(achievementName);
                Destroy(this);
            }
        }
    }
}