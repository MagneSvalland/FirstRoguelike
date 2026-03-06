using UnityEngine;
using System.Collections.Generic;
using FirstRoguelike.Stats;
using FirstRoguelike.Core;

namespace FirstRoguelike.Player
{
    public class PlayerStatSheet : MonoBehaviour
    {
        [Header("Base Stats")]
        [SerializeField] private float baseMoveSpeed = 5f;
        [SerializeField] private float baseDamage = 10f;
        [SerializeField] private float baseAttackSpeed = 1f;
        [SerializeField] private float baseMaxHealth = 100f;
        [SerializeField] private float baseArmor = 0f;

        private StatSheet _statSheet;
        public StatSheet StatSheet => _statSheet;

        private void Awake()
        {
            var baseStats = new Dictionary<StatType, float>
            {
                { StatType.MoveSpeed, baseMoveSpeed },
                { StatType.Damage, baseDamage },
                { StatType.AttackSpeed, baseAttackSpeed },
                { StatType.MaxHealth, baseMaxHealth },
                { StatType.Armor, baseArmor }
            };
            _statSheet = new StatSheet(baseStats);
        }

        private void OnEnable()
        {
            GameEvents.OnStatsChanged += OnStatsChanged;
        }

        private void OnDisable()
        {
            GameEvents.OnStatsChanged -= OnStatsChanged;
        }

        private void OnStatsChanged()
        {

        }
        
    }
}