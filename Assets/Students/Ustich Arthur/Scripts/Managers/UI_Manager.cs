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
        [SerializeField] private ActionBase _closeButtonAction;
        [SerializeField] private ActionBase _pauseButtomAction;
        [SerializeField] private ActionBase _gameOverAction;
        [SerializeField] private ActionBase _changeScoreText;

        [Space]
        [Header("Menu")]
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _homeButton;
        [SerializeField] private Button _closeMenuButton;
        [SerializeField] private TextMeshProUGUI _gameOverText;

        [Space]
        [Header("GameUI")]
        [SerializeField] private Button _pauseButton;

        private void Awake()
        {
            _closeButtonAction.Execute();

            _pauseButton.onClick.AddListener(PauseButtonAction);
            _closeMenuButton.onClick.AddListener(CloseMenuAction);
            _homeButton.onClick.AddListener(BackHomeButtonAction);
            _restartButton.onClick.AddListener(RestartGameButtonAction);
        }

        private void Update()
        {
            _changeScoreText.Execute();
            _gameOverAction.Execute();
        }

        private void PauseButtonAction() => _pauseButtomAction.Execute();

        private void CloseMenuAction() => _closeButtonAction.Execute();

        private void BackHomeButtonAction() => _backMainMenuAction.Execute();

        private void RestartGameButtonAction()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
    }
}