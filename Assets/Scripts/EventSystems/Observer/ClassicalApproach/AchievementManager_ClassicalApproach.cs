using System;
using System.Collections.Generic;
using UnityEngine;

namespace BilalAydin.EventSystems.Observer.ClassicalApproach
{
    public class AchievementManager_ClassicalApproach : Observer
    {
        [SerializeField] private List<string> completedAchievements = new List<string>();
        
        private void Start()
        {
            Subject[] subjects = FindObjectsOfType<Subject>();

            foreach (var subject in subjects)
            {
                subject.Subscribe(this);
            }

            Debug.Log(subjects.Length);
        }

        public override void OnNotify(object value)
        {
            string achievementName = value.ToString();
            Debug.Log($"Achievement Unlocked: {achievementName}");
            completedAchievements.Add(achievementName);
        }
    }
}