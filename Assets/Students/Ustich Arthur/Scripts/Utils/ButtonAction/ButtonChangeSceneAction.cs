using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ustich.Arthur.DoodleJump
{
    public class ButtonChangeSceneAction : ActionBase
    {
        [SerializeField] private ListOfScene _scene;

        public override void ExecuteInternal() => SceneManager.LoadScene((int)_scene);
    }
}

public enum ListOfScene
{
    MainMenu,
    Game
}