using UnityEngine;
using UnityEngine.SceneManagement;

namespace Varto.Examples.Managers
{
    public static class Varto_GameSessionManager
    {
        public static void RestartGameSession()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();

            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
