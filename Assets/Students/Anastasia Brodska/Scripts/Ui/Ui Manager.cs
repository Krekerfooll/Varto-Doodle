using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Varto.Examples.Utils;

public class UiManager : MonoBehaviour
{
    [Header("Global Settings")]
    [SerializeField] private string _onCollectCoinEventName;
    [SerializeField] private string _onGameOverEventName;
    [Space]
    [SerializeField] private int _coinsAmountPerEvent;

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

    private int _coinsCount = 0;

    private void Awake()
    {
        _gameScreenCoinsCounter.text = _coinsCount.ToString();
        _gameOverScreenCoinsCounter.text = _coinsCount.ToString();

        _pauseScreen.gameObject.SetActive(false);
        _gameOverScreen.gameObject.SetActive(false);

        _pauseButton.onClick.AddListener(OpenPauseScreen);
        _resumeButton.onClick.AddListener(ClosePauseScreen);
        _restartButton.onClick.AddListener(RestartCurrentScene);

        Varto_GlobalEventSender.OnEvent += OnAnyGlobalEvent;
    }

    private void OpenPauseScreen()
    {
        _pauseScreen.gameObject.SetActive(true);
    }
    private void ClosePauseScreen()
    {
        _pauseScreen.gameObject.SetActive(false);
    }

    private void RestartCurrentScene()
    {
        Varto_GlobalEventSender.OnEvent -= OnAnyGlobalEvent;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void OnAnyGlobalEvent(string eventName)
    {
        if (eventName == _onCollectCoinEventName)
        {
            _coinsCount += _coinsAmountPerEvent;

            _gameScreenCoinsCounter.text = _coinsCount.ToString();
            _gameOverScreenCoinsCounter.text = _coinsCount.ToString();
        }
        else if (eventName == _onGameOverEventName)
        {
            _gameOverScreen.gameObject.SetActive(true);
        }
    }
}
