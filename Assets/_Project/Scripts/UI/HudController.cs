using UnityEngine;
using TMPro;
using FirstRoguelike.Core;

namespace FirstRoguelike.UI
{
    public class HUDController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshProUGUI waveText;
        [SerializeField] private TextMeshProUGUI timerText;

        private float _timeAlive;
        private bool _isDead;
        private int _currentWave = 1;

        private void OnEnable()
        {
            GameEvents.OnPlayerDied += OnPlayerDied;
        }

        private void OnDisable()
        {
            GameEvents.OnPlayerDied -= OnPlayerDied;
        }

        private void Update()
        {
            if (_isDead) return;

            _timeAlive += Time.deltaTime;
            int minutes = Mathf.FloorToInt(_timeAlive / 60f);
            int seconds = Mathf.FloorToInt(_timeAlive % 60f);
            timerText.text = $"{minutes:00}:{seconds:00}";
        }

        public void SetWave(int wave)
        {
            _currentWave = wave;
            waveText.text = $"Wave {wave}";
        }

        private void OnPlayerDied()
        {
            _isDead = true;
        }
    }
}