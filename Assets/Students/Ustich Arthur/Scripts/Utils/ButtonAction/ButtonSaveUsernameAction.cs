using TMPro;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class ButtonSaveUsernameAction : ActionBase
    {
        [SerializeField] private TMP_InputField _usernameInput;
        [SerializeField] private GameSettingsManager _gameSettingsManager;

        public override void ExecuteInternal()
        {
            _gameSettingsManager.SetUsername(_usernameInput.text);
        }
    }
}