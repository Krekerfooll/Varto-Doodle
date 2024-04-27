using System.Collections.Generic;
using PVitaliy.Core;
using PVitaliy.Platform;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PVitaliy.UI
{
    public class SettingsUI : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown levelSelection;
        [SerializeField] private Button backButton;
        [SerializeField] private List<PlatformFactory> levels;
        public Button.ButtonClickedEvent BackButtonClick => backButton.onClick;

        private void Awake()
        {
            InitSelectOptions();
            levelSelection.onValueChanged.AddListener(OnDifficultyChanged);
        }

        private void InitSelectOptions()
        {
            levelSelection.options.Clear();
            levels.ForEach(level =>
            {
                levelSelection.options.Add(new TMP_Dropdown.OptionData(level.DropdownName));
            });
        }
        
        private void OnDifficultyChanged(int valueIndex) {
            GlobalEvents.CallEvent(EventNames.LevelGeneratorChanged, levels[valueIndex]);
        }
    }
}