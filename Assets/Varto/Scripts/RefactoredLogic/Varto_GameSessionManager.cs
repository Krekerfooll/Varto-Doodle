using UnityEngine;
using UnityEngine.SceneManagement;

namespace Varto.Examples.Managers
{
    public static class Varto_GameSessionManager
    {
        public static bool IsRestarting { get; private set; } = false;

        public static void RestartGameSession()
        {
            IsRestarting = true;
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex);
        }

        public static void ClearRestartFlag() => IsRestarting = false;
    }
}
