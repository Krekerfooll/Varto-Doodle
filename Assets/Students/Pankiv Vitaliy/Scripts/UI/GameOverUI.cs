using TMPro;
using UnityEngine;

namespace PVitaliy.UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private GameController gameController;
        [SerializeField] private TextMeshProUGUI scoreText;

        private void OnEnable()
        {
            scoreText.text = gameController.ConvertHeightToScore() + "";
        }
    }
}