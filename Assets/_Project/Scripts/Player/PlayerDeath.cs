using UnityEngine;
using FirstRoguelike.Core;

namespace FirstRoguelike.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        private HealthComponent _healthComponent;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
        }

        private void Start()
        {
            _healthComponent.OnDeath += HandleDeath;
        }

        private void OnDestroy()
        {
            _healthComponent.OnDeath -= HandleDeath;
        }

        private void HandleDeath()
        {
            Debug.Log("Player died!");
            GameEvents.PlayerDied();
            gameObject.SetActive(false);
        }
    }
}