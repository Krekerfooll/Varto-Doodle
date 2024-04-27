using TMPro;
using UnityEngine;

namespace PVitaliy.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        public void UpdateScore(int value)
        {
            scoreText.text = value.ToString();
        }
    }
}