using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Students.Drobiniak_Volodymyr.Scripts.UI.PauseMenu
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private bool pauseGame;
        [SerializeField] private GameObject pauseGameMenu;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pauseGame)
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
            pauseGame = false;
            pauseGameMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        public void PauseGame()
        {
            pauseGame = true;
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
