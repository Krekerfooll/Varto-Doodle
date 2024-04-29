using RomanDoliba.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RomanDoliba.UI
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private RectTransform _gameOverScreen;
        [SerializeField] private Button _restartButton;

        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartScene);
        }

        private void RestartScene()
        {
            var currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
    }
}
