using System;
using System.Collections.Generic;
using UnityEngine;

namespace BilalAydin.EventSystems.Observer.ClassicalApproach
{
    public class AchievementManager_ClassicalApproach : Observer
    {
        // Tamamlanan achievement'lerı devre dışı bıraktıktan
        // sonra editörde isimlerinin gözükmesi için bir liste
        // oluşturdum.
        [SerializeField] private List<string> completedAchievements = new List<string>();
        
        private void Start()
        {
            // Şimdilik Subject tipinde tek obje olduğu için
            // Subject tipindeki tüm objeleri bulmak istedim.
            // Ancak daha gelişmiş bir sistemde, achievementler
            // için bir tag belirleyip, bu tag ile arama yapmanız
            // daha sağlıklı olacaktır.
            Subject[] subjects = FindObjectsOfType<Subject>();

            // Subject'leri bulduktan sonra manager'ı hepsine kaydetmek
            // için foreach loop içerisinde hepsinin 'Subscribe' 
            // methodunu çağırıyor, parametresine bir 'Observer'
            // verilmesi gerektiği için 'this' keyword'ü ile bu
            // objeyi veriyorum.
            foreach (var subject in subjects)
            {
                subject.Subscribe(this);
            }
        }

        public override void OnNotify(object value)
        {
            // Achievement'ler tamamlandığında bir 'value'
            // verecek, bu value da achievement ismini barındıracak.
            // Veri tipinin 'object' olması ise, her veri tipinin
            // 'object' tipini inherit alması, yani her veri tipinin
            // 'object' yerine geçebilmesidir. Böylece istenilen veri
            // istenilen şekilde verilip, işlenebilir.
            string achievementName = value.ToString();
            Debug.Log($"Achievement Unlocked: {achievementName}");
            completedAchievements.Add(achievementName);
        }
    }
}