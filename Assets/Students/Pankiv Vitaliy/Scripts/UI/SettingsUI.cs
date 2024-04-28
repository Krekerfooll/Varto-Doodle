using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PVitaliy.UI
{
    public class SettingsUI : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown levelSelection;
        [SerializeField] private Button backButton;
        public Button.ButtonClickedEvent BackButtonClick => backButton.onClick;
    }
}