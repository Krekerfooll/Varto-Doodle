using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PVitaliy.UI
{
    public class PauseUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private Button resumeButton;
        public Button.ButtonClickedEvent ResumeButtonClick => resumeButton.onClick;

        public string ScoreText
        {
            set => scoreText.text = value;
        }
    }
}