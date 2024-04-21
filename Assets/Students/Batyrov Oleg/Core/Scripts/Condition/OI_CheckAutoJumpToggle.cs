using UnityEngine;
using UnityEngine.UI;

namespace OIMOD.Core.Component
{
    public class OI_CheckAutoJumpToggle : MonoBehaviour
    {
        [SerializeField] private Toggle toggleButton;
        [SerializeField] private OI_GameData gameData;


        private void Awake()
        {
            
            toggleButton.onValueChanged.AddListener(isOn => ToggleAutoJump(isOn));
        }
        private void Update()
        {
            toggleButton.isOn = gameData.playerAutoJump;
        }
        private void ToggleAutoJump(bool toggleState)
        {
            if (toggleState) gameData.playerAutoJump = true;
            else gameData.playerAutoJump = false;
        }
    }
}