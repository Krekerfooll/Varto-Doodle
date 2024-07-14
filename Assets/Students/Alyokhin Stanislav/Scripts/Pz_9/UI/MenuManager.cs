using Alokhin.Stanislav.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Global Settings")]
    [SerializeField] private string _onCollectCoinEventName;
    [SerializeField] private string _onGameOverEventName;
    [SerializeField] private int _coinsAmountPerEvent;
    [Space]
    [SerializeField] Transform _target;
    [SerializeField] private float _fall;
    [Header("MainMenu")]
    [SerializeField] GameObject _mainMenuPanel;
    [SerializeField] GameObject _startButton;
    [SerializeField] GameObject _settingButton;
    [SerializeField] GameObject _exitButtonOne;
    [SerializeField] GameObject _restartButtonOne;

    [Header("Settings")]
    [SerializeField] GameObject _settingsPanel;
    [SerializeField] GameObject _backButton;

    [Header("GameScreen")]
    [SerializeField] TextMeshProUGUI _gameScreenCoinsCounte;
    [SerializeField] GameObject _gameScreen;
    [SerializeField] GameObject _pauseButton;

    [Header("PauseMenu")]
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _backToGame;
    [SerializeField] GameObject _backToMenu;

    [Header("GameOverScreen")]
    [SerializeField] TextMeshProUGUI _gameOverCoinsCoute;
    [SerializeField] GameObject _gameOverScreen;
    [SerializeField] GameObject _restartButtonTwo;
    [SerializeField] GameObject _exitGameTwo;

    private bool _isPaused = false;
    private int _playerCount = 0;
    private float _lastPlatformY;

    private void Awake()
    {
        _isPaused = true;
        Time.timeScale = 0f;

    }
    private void Start()
    {
        _gameScreenCoinsCounte.text = _playerCount.ToString();
        _gameOverCoinsCoute.text = _playerCount.ToString();
        _mainMenuPanel.SetActive(true);
        _settingsPanel.SetActive(false);
        _gameScreen.SetActive(false);
        _pauseMenu.SetActive(false);
        _gameOverScreen.SetActive(false);

        _startButton.GetComponent<Button>().onClick.AddListener(StartGame);
        _settingButton.GetComponent<Button>().onClick.AddListener(OpenSettings);
        _exitButtonOne.GetComponent<Button>().onClick.AddListener(ExitGame);
        _backButton.GetComponent<Button>().onClick.AddListener(CloseSettings);

        _pauseButton.GetComponent<Button>().onClick.AddListener(OpenPause);
        _backToGame.GetComponent<Button>().onClick.AddListener (ClosePause);
        _backToMenu.GetComponent<Button>().onClick.AddListener(BackToMenu);
        _restartButtonOne.GetComponent<Button>().onClick.AddListener(RestartFromMenu);

        _restartButtonTwo.GetComponent<Button>().onClick.AddListener(RestartCurrentscene);
        
        _lastPlatformY = _target.position.y;
    }
    private void Update()
    {
        CheckPlayerFall();
    }

    private void CheckPlayerFall()
    {
        if(_target.position.y < _lastPlatformY - _fall)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        _gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }
  //  private void ResetGame()
  //  {
  //      Time.timeScale = 1f;
  //      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  //  }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            _lastPlatformY = _target.position.y;
        }
    }
    private void StartGame()
    {
        _isPaused = false;
        Time.timeScale = 1f;
        _gameScreen.SetActive(true);
        _mainMenuPanel.SetActive(false);
        
    }
    private void OpenPause()
    {
        _isPaused = true;
        _pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    private void ClosePause()
    {
        _gameScreen.SetActive(true);
        _pauseMenu.SetActive(false);
        _isPaused = false;
        Time.timeScale = 1f;
    } 
    private void BackToMenu()
    {
        _isPaused = true;
        Time.timeScale = 0f;
        _mainMenuPanel.SetActive(true);
        _pauseMenu.SetActive(false);
    }
    private void RestartFromMenu()
    {
        _isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _mainMenuPanel.SetActive(false);
        _gameScreen.SetActive(true);
    }
    private void OpenSettings()
    {
        _mainMenuPanel.SetActive(false);
        _settingsPanel.SetActive(true);
    }
    private void CloseSettings()
    {
        _settingsPanel.SetActive(false);
        _mainMenuPanel.SetActive(true);
    }
    private void RestartCurrentscene()
    {
        GlobalEventSender.OnEvent -= OnAnyGlobalEvent;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    private void OnAnyGlobalEvent(string eventName)
    {
        if (eventName == _onCollectCoinEventName)
        {
            _playerCount += _coinsAmountPerEvent;

            _gameScreenCoinsCounte.text = _playerCount.ToString();
            _gameOverCoinsCoute.text = _playerCount.ToString();
        }
        else if (eventName == _onCollectCoinEventName)
        {
            _gameOverScreen.gameObject.SetActive(true);
        }
    }
    private void ExitGame()
    {
        Application.Quit();
    }
}
