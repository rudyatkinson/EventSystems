using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace BilalAydin.Character
{
    public class CharacterSkillController : MonoBehaviour
    {
        [SerializeField] private AttackSkill attackSkill;
        [SerializeField] private DashSkill dashSkill;

        public KeyCode AttackKey;
        public KeyCode DashKey;

        private void Update()
        {
            if (Input.GetKeyDown(AttackKey)) attackSkill.Use();
            if (Input.GetKeyDown(DashKey)) dashSkill.Use();
        }
    }
}