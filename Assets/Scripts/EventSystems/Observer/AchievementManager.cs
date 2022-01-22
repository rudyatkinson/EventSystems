using System;
using System.Collections.Generic;
using UnityEngine;

namespace BilalAydin.Observer {
    public class AchievementManager : MonoBehaviour
    {
        [SerializeField] private List<string> completedAchievements = new List<string>();
        
        private void OnEnable()
        {
            PressSpaceAchievement.OnKeyDown.AddListener(PressSpaceAchievement_OnKeyDown);
        }

        private void OnDisable()
        {
            PressSpaceAchievement.OnKeyDown.RemoveListener(PressSpaceAchievement_OnKeyDown);
        }

        private void PressSpaceAchievement_OnKeyDown(string achievementName)
        {
            Debug.Log($"Achievement Unlocked: {achievementName}");
            completedAchievements.Add(achievementName);
        }
    }
}
