using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Varto.Examples.UI
{
    public class Varto_UiManager : MonoBehaviour
    {
        public event Action OnRestartRequested;

        [Space]
        [Header("Game Screen")]
        [SerializeField] private RectTransform _gameScreen;
        [SerializeField] private TextMeshProUGUI _gameScreenCoinsCounter;
        [SerializeField] private Button _pauseButton;

        [Space]
        [Header("Pause Screen")]
        [SerializeField] private RectTransform _pauseScreen;
        [SerializeField] private Button _resumeButton;

        [Space]
        [Header("Game Over Screen")]
        [SerializeField] private RectTransform _gameOverScreen;
        [SerializeField] private TextMeshProUGUI _gameOverScreenCoinsCounter;
        [SerializeField] private Button _restartButton;

        public int CoinsCount { get; private set; } = 0;

        public void Init(int coinsAmount)
        {
            CoinsCount = coinsAmount;

            _gameScreenCoinsCounter.text = CoinsCount.ToString();
            _gameOverScreenCoinsCounter.text = CoinsCount.ToString();

            _pauseScreen.gameObject.SetActive(false);
            _gameOverScreen.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _pauseButton.onClick.AddListener(OpenPauseScreen);
            _resumeButton.onClick.AddListener(ClosePauseScreen);
            _restartButton.onClick.AddListener(() => OnRestartRequested?.Invoke());
        }
        private void OnDisable()
        {
            _pauseButton.onClick.RemoveAllListeners();
            _resumeButton.onClick.RemoveAllListeners();
            _restartButton.onClick.RemoveAllListeners();
        }

        public void AddCoins(int amount)
        {
            CoinsCount += amount;
            _gameScreenCoinsCounter.text = CoinsCount.ToString();
            _gameOverScreenCoinsCounter.text = CoinsCount.ToString();
        }

        public void ShowGameOverScreen()
        {
            _gameOverScreen.gameObject.SetActive(true);
        }

        private void OpenPauseScreen()
        {
            _pauseScreen.gameObject.SetActive(true);
        }
        private void ClosePauseScreen()
        {
            _pauseScreen.gameObject.SetActive(false);
        }
    }
}
