using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Varto.Examples.Utils;

public class UI : MonoBehaviour
{
    [Header("Global Settings")]
    [SerializeField] private string _onGameOverEventName;
    [SerializeField] private string _onScoreEventName;
    [Space]
    [SerializeField] private int _scoreAmountPerEvent;

    [Space]
    [Header("Start Menu Screen")]
    [SerializeField] private RectTransform _startMenuScreen;
    [SerializeField] private Button _playButton;

    [Space]
    [Header("Game Screen")]
    [SerializeField] private RectTransform _gameScreen;
    [SerializeField] private RectTransform _startMenuButtonIcon;
    [SerializeField] private TextMeshProUGUI _gameScreenCoinsCounter;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _startMenuButton;

    [Space]
    [Header("Game Over Screen")]
    [SerializeField] private RectTransform _gameOverScreen;
    [SerializeField] private TextMeshProUGUI _gameOverScreenCoinsCounter;
    [SerializeField] private Button _restartButton;

    [Header("Game objects")]
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _spawner;

    private int _scoreCount = 0;
    private bool _isPause = false;

    private void Awake()
    {
        _gameScreenCoinsCounter.text = _scoreCount.ToString();
        _gameOverScreenCoinsCounter.text = _scoreCount.ToString();

        _startMenuScreen.gameObject.SetActive(true);
        _gameScreen.gameObject.SetActive(false);
        _gameOverScreen.gameObject.SetActive(false);

        _playButton.onClick.AddListener(StartPlay);
        _pauseButton.onClick.AddListener(Pause);
        _startMenuButton.onClick.AddListener(StartMenu);
        _restartButton.onClick.AddListener(RestartCurrentScene);

        EventSender.OnEvent += OnAnyGlobalEvent;
    }
    private void StartPlay()
    {
        _startMenuScreen.gameObject.SetActive(false);
        _gameScreen.gameObject.SetActive(true);
        _player.SetActive(true);
        _spawner.SetActive(true);
    }
    private void Pause()
    {
        _isPause = !_isPause;
        _startMenuButtonIcon.gameObject.SetActive(_isPause);
    }
    private void StartMenu()
    {
        _startMenuScreen.gameObject.SetActive(true);

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

        EventSender.OnEvent -= OnAnyGlobalEvent;
    }

    private void RestartCurrentScene()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

        EventSender.OnEvent -= OnAnyGlobalEvent;
    }

    private void OnAnyGlobalEvent(string eventName)
    {
        if (eventName == _onScoreEventName)
        {
            _scoreCount += _scoreAmountPerEvent;

            _gameScreenCoinsCounter.text = _scoreCount.ToString();
            _gameOverScreenCoinsCounter.text = _scoreCount.ToString();
        }

        else if (eventName == _onGameOverEventName)
        {
            _gameOverScreen.gameObject.SetActive(true);
            _gameScreen.gameObject.SetActive(false);
        }
    }
}
