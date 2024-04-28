using System;
using PVitaliy.Platform;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PVitaliy.Components
{
    public class LevelSelectionButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI label;
        [SerializeField] private GameObject selectedView;
        private PlatformFactory _targetFactory;
        private bool _isSelected;
        public Action<LevelSelectionButton> OnSelectedChanged;
        public PlatformFactory Factory => _targetFactory;

        public void Init(PlatformFactory target)
        {
            button.onClick.AddListener(() =>
            {
                SetActive(true);
            });
            _targetFactory = target;
            label.text = target.DropdownName;
        }
        public void SetActive (bool value)
        {
            if (_isSelected == value) return;
            _isSelected = value;
            selectedView.SetActive(value);
            if (value)
            {
                OnSelectedChanged.Invoke(this);
            }
        }
    }
}