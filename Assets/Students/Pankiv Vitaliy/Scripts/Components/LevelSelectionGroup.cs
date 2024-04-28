using System.Collections.Generic;
using PVitaliy.Core;
using PVitaliy.Platform;
using UnityEngine;

namespace PVitaliy.Components
{
    public class LevelSelectionGroup : MonoBehaviour
    {
        [SerializeField] private List<PlatformFactory> levels;
        [SerializeField] private GameObject container;
        [SerializeField] private LevelSelectionButton buttonPrefab;

        private LevelSelectionButton _activeButton;

        private void Awake()
        {
            InitLevelsList();
        }

        private void InitLevelsList()
        {
            _activeButton = null;
            foreach (Transform children in container.transform)
                Destroy(children.gameObject);
            
            levels.ForEach(InitNewButton);
        }

        private void InitNewButton(PlatformFactory factory)
        {
            var button = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, container.transform);
            button.Init(factory);
            button.name = "LevelType " + factory.DropdownName;
            button.OnSelectedChanged += OnDifficultyChanged;
            if (!_activeButton) button.SetActive(true);
        }

        private void OnDifficultyChanged(LevelSelectionButton button)
        {
            _activeButton?.SetActive(false);
            _activeButton = button;
            GlobalEvents.CallEvent(EventNames.LevelGeneratorChanged, _activeButton.Factory);
        }
    }
}