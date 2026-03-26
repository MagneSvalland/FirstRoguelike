using System;

namespace FirstRoguelike.Core
{
    public static class GameEvents
    {
        public static event Action<string> OnUpgradePicked;
        public static event Action OnStatsChanged;
        public static event Action OnPlayerDied;

        public static void UpgradePicked(string upgradeId)
        {
            OnUpgradePicked?.Invoke(upgradeId);
        }

        public static void StatsChanged()
        {
            OnStatsChanged?.Invoke();
        }

        public static void PlayerDied()
        {
            OnPlayerDied?.Invoke();
        }
    }
}