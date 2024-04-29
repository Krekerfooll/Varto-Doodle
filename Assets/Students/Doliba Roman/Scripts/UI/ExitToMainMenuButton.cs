using RomanDoliba.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RomanDoliba.UI
{
    public class ExitToMainMenuButton : MonoBehaviour
    {
        [SerializeField] private Button _exitToMainMenuButton;
        [SerializeField] private GameOverSceneActivate _gameOverSceneActivate;

            private void Awake()
            {
                _exitToMainMenuButton.onClick.AddListener(ExitToMainMenu);
            }

            private void ExitToMainMenu()
            {
                SceneManager.LoadScene(0);
                OnTrigerEventSender.OnEvent -= _gameOverSceneActivate.OnPlayerDeath;
            }
    }
}
