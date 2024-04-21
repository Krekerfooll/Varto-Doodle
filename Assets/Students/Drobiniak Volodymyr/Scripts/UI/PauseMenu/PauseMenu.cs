using UnityEngine;
using UnityEngine.SceneManagement;

namespace Students.Drobiniak_Volodymyr.Scripts.UI.PauseMenu
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseGameMenu;
        private bool _pauseGame;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_pauseGame)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

        public void ResumeGame()
        {
            _pauseGame = false;
            pauseGameMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        public void PauseGame()
        {
            _pauseGame = true;
            pauseGameMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        public void LoadMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
