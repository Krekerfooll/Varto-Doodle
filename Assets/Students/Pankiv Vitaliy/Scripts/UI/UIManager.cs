using UnityEngine;

namespace PVitaliy.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private MainUI mainUI;
        [SerializeField] private GameUI gameUI;
        [SerializeField] private PauseUI pauseUI;
        [SerializeField] private GameOverUI gameOverUI;
        [SerializeField] private SettingsUI settingsUI;
        [SerializeField] private GameController gameController;

        private void Start()
        {
            mainUI.ExitButtonClick.AddListener(() =>
            {
                Application.Quit();
            });
            mainUI.StartGameButtonClick.AddListener(StartGame);
            mainUI.SettingsButtonClick.AddListener(OpenSettings);
            
            settingsUI.BackButtonClick.AddListener(SettingsBackToMenu);
            
            gameUI.PauseButtonClick.AddListener(PauseGame);
            
            pauseUI.ResumeButtonClick.AddListener(ResumeGame);
            
            gameOverUI.NewGameButtonClicked.AddListener(StartNewGame);
            gameOverUI.MainMenuButtonClicked.AddListener(GameOverBackToMenu);
        }

        private void StartGame()
        {
            HideUIS(gameOverUI, mainUI);
            ShowUIS(gameUI);
            gameController.SetPlayerActive(true);
            gameController.gameObject.SetActive(true);
        }

        private void OpenSettings()
        {
            HideUIS(mainUI, pauseUI, gameOverUI);
            ShowUIS(settingsUI);
        }

        private void PauseGame()
        {
            ShowUIS(pauseUI);
            pauseUI.ScoreText = gameController.ConvertHeightToScore().ToString();
            gameController.SetTimeScale(0);
            gameController.gameObject.SetActive(false);
        }

        private void ResumeGame()
        {
            HideUIS(pauseUI);
            gameController.SetTimeScale(1);
            gameController.gameObject.SetActive(true);
        }

        public void OnGameOver()
        {
            HideUIS(gameUI);
            ShowUIS(gameOverUI);
            gameController.SetPlayerActive(false);
            gameController.gameObject.SetActive(false);
        }

        private void GameOverBackToMenu()
        {
            HideUIS(gameOverUI);
            ShowUIS(mainUI);
            gameController.SetPlayerActive(false);
            gameController.GenerateNewLevel();
        }

        private void StartNewGame()
        {
            gameController.GenerateNewLevel();
            StartGame();
        }

        private void SettingsBackToMenu()
        {
            HideUIS(settingsUI);
            ShowUIS(mainUI);
        }

        private void HideUIS(params MonoBehaviour[] hide)
        {
            foreach (var canvas in hide)
            {
                canvas.gameObject.SetActive(false);
            }
        }

        private void ShowUIS(params MonoBehaviour[] show)
        {
            foreach (var canvas in show)
            {
                canvas.gameObject.SetActive(true);
            }
        }

        public int GameScore
        {
            set => gameUI.UpdateScore(value.ToString());
        }
    }
}