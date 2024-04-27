using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ustich.Arthur.DoodleJump
{
    public class UI_Manager : MonoBehaviour
    {
        [Header("Actions")]
        [SerializeField] private ActionBase _backMainMenuAction;

        [Space]
        [Header("TargetSetting")]
        [SerializeField] private GameObject _target;
        private int score = 0;

        [Space]
        [Header("Menu")]
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _homeButton;
        [SerializeField] private Button _closeMenuButton;
        [SerializeField] private TextMeshProUGUI _gameOverText;
        [SerializeField] private GameObject _panel;
        [SerializeField] private GameObject _menuButtons;

        [Space]
        [Header("GameUI")]
        [SerializeField] private Button _pauseButton;
        [SerializeField] private TextMeshProUGUI _scoreText;

        private void Awake()
        {
            _panel.SetActive(false);
            _menuButtons.SetActive(false);
            _gameOverText.gameObject.SetActive(false);
            _closeMenuButton.gameObject.SetActive(false);
            _pauseButton.gameObject.SetActive(true);

            _pauseButton.onClick.AddListener(PauseButtonAction);
            _closeMenuButton.onClick.AddListener(CloseMenuAction);
            _homeButton.onClick.AddListener(BackHomeButtonAction);
            _restartButton.onClick.AddListener(RestartGameButtonAction);

            _scoreText.text = score.ToString();
        }

        private void Update()
        {
            if (_target != null && _target.transform.position.y > score)
            {
                score = (int)_target.transform.position.y;
                _scoreText.text = score.ToString();
            }

            if (_target == null)
                GameOver();
        }

        private void PauseButtonAction()
        {
            _panel.SetActive(true);
            _menuButtons.SetActive(true);
            _closeMenuButton.gameObject.SetActive(true);
            _pauseButton.gameObject.SetActive(false);
        }

        private void CloseMenuAction()
        {
            _panel.SetActive(false);
            _menuButtons.SetActive(false);
            _closeMenuButton.gameObject.SetActive(false);
            _pauseButton.gameObject.SetActive(true);
        }

        private void BackHomeButtonAction() => _backMainMenuAction.Execute();

        private void RestartGameButtonAction()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }

        private void GameOver()
        {
            _panel.SetActive(true);
            _menuButtons.SetActive(true);
            _closeMenuButton.gameObject.SetActive(true);
            _gameOverText.gameObject.SetActive(true);
            _pauseButton.gameObject.SetActive(false);
        }
    }
}