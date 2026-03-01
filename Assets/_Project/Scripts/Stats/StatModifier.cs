namespace FirstRoguelike.Stats
{
    public enum ModifierType
    {
        Flat,           // e.g. +10 damage
        PercentAdd,     // e.g. +10% damage (these stack additively)
        PercentMultiply // e.g. x1.1 damage (these stack multiplicatively)
    }

    public class StatModifier
    {
        public StatType Stat { get; }
        public ModifierType Type { get; }
        public float Value { get; }
        public object Source { get; }

        public StatModifier(StatType stat, ModifierType type, float value, object source)
        {
            Stat = stat;
            Type = type;
            Value = value;
            Source = source;
        }
    }
}