using BilalAydin.ScriptableObject.Events;
using UnityEngine;

namespace BilalAydin.Character
{
    public abstract class Skill : MonoBehaviour
    {
        public string SkillName;
        public int SkillCooldown;

        public SkillEvent OnSkillUsed;

        public virtual void Use()
        {
            OnSkillUsed.Invoke(this);
        }
    }
}