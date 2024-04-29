using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RomanDoliba.UI
{
    public class StartButton : MonoBehaviour
    {
        [SerializeField] private Button _startGameButton;

        private void Awake()
        {
            _startGameButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }
    }
}
