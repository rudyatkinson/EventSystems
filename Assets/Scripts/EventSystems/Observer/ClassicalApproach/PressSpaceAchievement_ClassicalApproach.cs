using UnityEngine;
using UnityEngine.Events;

namespace BilalAydin.EventSystems.Observer.ClassicalApproach
{
    public class PressSpaceAchievement_ClassicalApproach : Subject
    {
        // AchievementManager'ın bilgilendirilmesi için vereceğimiz
        // veri.
        [SerializeField] private string achievementName;

        // Achievement'ın tamamlanması için basılması gereken tuşu
        // lambda expression ile belirliyor ve sürekli check etmesini
        // sağlıyorum.
        private bool keyDown => Input.GetKeyDown(KeyCode.A);

        private void Update()
        {
            // A tuşuna basıldığında 'Subject' den gelen Invoke methodunu
            // çağırarak object tipindeki parametresine de achievement adını
            // verdikten sonra scripti devredışı bırakıyorum.
            if (keyDown)
            {
                Invoke(achievementName);
                enabled = false;
            }
        }
    }
}