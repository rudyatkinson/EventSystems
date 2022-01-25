using System;
using UnityEngine;
using UnityEngine.Events;

namespace BilalAydin.Observer
{
    public class PressSpaceAchievement: MonoBehaviour
    {
        [SerializeField] private string achievementName;
        
        private bool keyDown => Input.GetKeyDown(KeyCode.A);

        // Classical Approach'tan tek farkı UnityEvent kullanmamız.
        // OnKeyDown referans adıyla oluşturduğumuz ve static yaptığım
        // UnityEvent'e manager tarafından listener eklenecek, böylece
        // achievement tamamlandığında tıpkı Classical Approach'taki 
        // gibi manager bilgilendirilecek.
        public static UnityEvent<string> OnKeyDown = new UnityEvent<string>();

        private void Update()
        {
            if (keyDown)
            {
                OnKeyDown?.Invoke(achievementName);
                enabled = false;
            }
        }
    }
}