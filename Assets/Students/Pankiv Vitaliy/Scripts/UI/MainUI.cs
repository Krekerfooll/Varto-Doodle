using UnityEngine;
using UnityEngine.UI;

namespace PVitaliy.UI
{
    public class MainUI : MonoBehaviour
    {
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button exitButton;
        public Button.ButtonClickedEvent StartGameButtonClick => startGameButton.onClick;
        public Button.ButtonClickedEvent SettingsButtonClick => settingsButton.onClick;
        public Button.ButtonClickedEvent ExitButtonClick => exitButton.onClick;
    }
}