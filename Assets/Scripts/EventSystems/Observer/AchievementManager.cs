using System;
using System.Collections.Generic;
using UnityEngine;

namespace BilalAydin.Observer {
    public class AchievementManager : MonoBehaviour
    {
        [SerializeField] private List<string> completedAchievements = new List<string>();
        
        // Static OnKeyDown event'ine manager'daki 'OnAchievementSucceeded' methodunu
        // OnEnable'da ekliyor, OnDisable'da da çıkarıyoruz. Bir şekilde manager'ın
        // devredışı kaldığı ancak achievementların hala aktif olduğu ve tamamlandığı
        // durumlarda, 'OnAchievementSucceeded' çağıralamayacağı için exception ortaya
        // çıkar ve işlemler yarıda kesilir, devamında olması gerektiği gibi çalışmamaya
        // başlar. Bu yüzden her zaman OnDisable methodunda listener'ı silmekte fayda vardır.
        private void OnEnable()
        {
            PressSpaceAchievement.OnKeyDown.AddListener(OnAchievementSucceeded);
        }

        private void OnDisable()
        {
            PressSpaceAchievement.OnKeyDown.RemoveListener(OnAchievementSucceeded);
        }

        private void OnAchievementSucceeded(string achievementName)
        {
            Debug.Log($"Achievement Unlocked: {achievementName}");
            completedAchievements.Add(achievementName);
        }
    }
}
