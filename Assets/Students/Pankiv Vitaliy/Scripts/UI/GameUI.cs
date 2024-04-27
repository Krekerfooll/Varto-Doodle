using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PVitaliy.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private Button pauseButton;
        public Button.ButtonClickedEvent PauseButtonClick => pauseButton.onClick;

        public void UpdateScore(string value)
        {
            scoreText.text = value;
        }
    }
}