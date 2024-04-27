using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PVitaliy.UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private GameController gameController;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private Button newGameButton;
        [SerializeField] private Button mainMenuButton;
        public Button.ButtonClickedEvent NewGameButtonClicked => newGameButton.onClick;
        public Button.ButtonClickedEvent MainMenuButtonClicked => mainMenuButton.onClick;
        private void OnEnable()
        {
            scoreText.text = gameController.ConvertHeightToScore() + "";
        }
    }
}