using System.Collections.Generic;
using System.Linq;

namespace FirstRoguelike.Stats
{
    public class StatSheet
    {
        private readonly Dictionary<StatType, float> _baseStats;
        private readonly List<StatModifier> _modifiers;

        public StatSheet(Dictionary<StatType, float> baseStats)
        {
            _baseStats = baseStats;
            _modifiers = new List<StatModifier>();
        }

        public void AddModifier(StatModifier modifier)
        {
            _modifiers.Add(modifier);
        }

        public void RemoveModifiersBySource(object source)
        {
            _modifiers.RemoveAll(m => m.Source == source);
        }

        public float GetStat(StatType stat)
        {
            float baseValue = _baseStats.TryGetValue(stat, out float val) ? val : 0f;

            // Step 1: Sum all flat modifiers
            float flatBonus = _modifiers
                .Where(m => m.Stat == stat && m.Type == ModifierType.Flat)
                .Sum(m => m.Value);

            // Step 2: Sum all percent add modifiers
            float percentAdd = _modifiers
                .Where(m => m.Stat == stat && m.Type == ModifierType.PercentAdd)
                .Sum(m => m.Value);

            // Step 3: Multiply all percent multiply modifiers
            float percentMultiply = _modifiers
                .Where(m => m.Stat == stat && m.Type == ModifierType.PercentMultiply)
                .Aggregate(1f, (acc, m) => acc * (1f + m.Value));

            return (baseValue + flatBonus) * (1f + percentAdd) * percentMultiply;
        }
    }
}