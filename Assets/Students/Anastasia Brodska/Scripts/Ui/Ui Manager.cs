using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("Global Settings")]
    [SerializeField] private string _onCollectCoinEventName;
    [SerializeField] private string _onGameOverEventName;
    [Space]
    [SerializeField] private int _coinsAmountPerEvent;

    [Space]
    [Header("Start Screen")]
    [SerializeField] private RectTransform _startScreen;
    [SerializeField] private Button _startButton;

    [Space]
    [Header("Start in game Screen")]
    [SerializeField] private RectTransform _startingameScreen;
    [SerializeField] private Button _startingameButton;
    [SerializeField] private Button _resumeingameButton;


    [Space]
    [Header("Game Screen")]
    [SerializeField] private RectTransform _gameScreen;
    [SerializeField] private TextMeshProUGUI _gameScreenCoinsCounter;
    [SerializeField] private Button _pauseButton;

    [Space]
    [Header("Pause Screen")]
    [SerializeField] private RectTransform _pauseScreen;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _exitButton;

    [Space]
    [Header("Game Over Screen")]
    [SerializeField] private RectTransform _gameOverScreen;
    [SerializeField] private TextMeshProUGUI _gameOverScreenCoinsCounter;
    [SerializeField] private Button _restartButton;

    private int _coinsCount = 0;


    private void Awake()
    {
        InitializeScreens();
        InitializeButtons();
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    private void InitializeScreens()
    {
        _startScreen.gameObject.SetActive(true);
        _startingameScreen.gameObject.SetActive(false);
        _gameScreen.gameObject.SetActive(false);
        _pauseScreen.gameObject.SetActive(false);
        _gameOverScreen.gameObject.SetActive(false);
    }

    private void InitializeButtons()
    {
        _startButton.onClick.AddListener(StartGame);
        _startingameButton.onClick.AddListener(RestartCurrentScene);
        _resumeingameButton.onClick.AddListener(CloseStartScreen);
        _pauseButton.onClick.AddListener(OpenPauseScreen);
        _resumeButton.onClick.AddListener(ClosePauseScreen);
        _exitButton.onClick.AddListener(OpenInGameStartScreen);
        _restartButton.onClick.AddListener(RestartCurrentScene);
    }

    private void SubscribeToEvents()
    {
        GlobalEvents.OnEvent += OnAnyGlobalEvent;
        PlayerMovement.OnPlayerDeath += OnPlayerDeath;
    }

    private void UnsubscribeFromEvents()
    {
        GlobalEvents.OnEvent -= OnAnyGlobalEvent;
        PlayerMovement.OnPlayerDeath -= OnPlayerDeath;
    }

    private void StartGame()
    {
        CloseStartScreen();
    }

    private void OpenInGameStartScreen()
    {
        _startingameScreen.gameObject.SetActive(true);
        _gameScreen.gameObject.SetActive(false);
        _pauseScreen.gameObject.SetActive(false);
        _gameOverScreen.gameObject.SetActive(false);
    }

    private void CloseStartScreen()
    {
        _startScreen.gameObject.SetActive(false);
        _startingameScreen.gameObject.SetActive(false);
        _gameScreen.gameObject.SetActive(true);
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
        UnsubscribeFromEvents();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnAnyGlobalEvent(string eventName)
    {
        if (eventName == _onCollectCoinEventName)
        {
            _coinsCount += _coinsAmountPerEvent;
            UpdateCoinsCounter();
        }
        else if (eventName == _onGameOverEventName)
        {
            _gameScreen.gameObject.SetActive(false);
            _gameOverScreen.gameObject.SetActive(true);
        }
    }

    private void OnPlayerDeath(string eventName)
    {
        if (eventName == _onGameOverEventName)
        {
            _gameScreen.gameObject.SetActive(false);
            _gameOverScreen.gameObject.SetActive(true);
        }
    }

    private void UpdateCoinsCounter()
    {
        _gameScreenCoinsCounter.text = _coinsCount.ToString();
        _gameOverScreenCoinsCounter.text = _coinsCount.ToString();
    }
}

