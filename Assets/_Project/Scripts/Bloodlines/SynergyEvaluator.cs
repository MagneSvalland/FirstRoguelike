using UnityEngine;
using System.Collections.Generic;
using FirstRoguelike.Stats;
using FirstRoguelike.Core;
using FirstRoguelike.Player;

namespace FirstRoguelike.Bloodlines
{
    public class SynergyEvaluator : MonoBehaviour
    {
        private PlayerStatSheet _playerStatSheet;
        private TraitTracker _traitTracker;
        private HashSet<SynergyTierSO> _activeTiers = new();

        private void Awake()
        {
            _playerStatSheet = FindFirstObjectByType<PlayerStatSheet>();
            _traitTracker = GetComponent<TraitTracker>();
        }

        private void OnEnable()
        {
            GameEvents.OnStatsChanged += Evaluate;
        }

        private void OnDisable()
        {
            GameEvents.OnStatsChanged -= Evaluate;
        }

        private void Evaluate()
        {
            var counts = _traitTracker.GetAllCounts();

            foreach (var kvp in counts)
            {
                BloodlineSO bloodline = kvp.Key;
                int count = kvp.Value;

                foreach (SynergyTierSO tier in bloodline.tiers)
                {
                    if (count >= tier.threshold && !_activeTiers.Contains(tier))
                    {
                        ActivateTier(tier);
                    }
                }
            }
        }

        private void ActivateTier(SynergyTierSO tier)
        {
            _activeTiers.Add(tier);
            Debug.Log($"Synergy activated: {tier.tierName} ({tier.threshold})!");

            foreach (StatModifierSO modSO in tier.modifiers)
            {
                var modifier = new StatModifier(
                    modSO.statType,
                    modSO.modifierType,
                    modSO.value,
                    tier
                );
                _playerStatSheet.StatSheet.AddModifier(modifier);
            }

            GameEvents.StatsChanged();
        }
    }
}