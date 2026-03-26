using UnityEngine;
using UnityEngine.SceneManagement;
using FirstRoguelike.Core;
using TMPro;

namespace FirstRoguelike.UI
{
    public class GameOverUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private TextMeshProUGUI timeAliveText;

        private float _timeAlive;
        private bool _isDead;

        private void OnEnable()
        {
            GameEvents.OnPlayerDied += ShowGameOver;
        }

        private void OnDisable()
        {
            GameEvents.OnPlayerDied -= ShowGameOver;
        }

        private void Update()
        {
            if (!_isDead)
                _timeAlive += Time.deltaTime;
        }

        private void ShowGameOver()
        {
            _isDead = true;
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;

            int minutes = Mathf.FloorToInt(_timeAlive / 60f);
            int seconds = Mathf.FloorToInt(_timeAlive % 60f);
            timeAliveText.text = $"You survived {minutes:00}:{seconds:00}";
        }

        public void RestartGame()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}