using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class ButtonCloseGameAction : ActionBase
    {
        public override void ExecuteInternal()
        {
            ExitGame();
        }

        private void ExitGame()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}