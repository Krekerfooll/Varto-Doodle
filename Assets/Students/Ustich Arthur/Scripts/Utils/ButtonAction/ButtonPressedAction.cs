using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ustich.Arthur.DoodleJump
{
    public class ButtonPressedAction : MonoBehaviour
    {
        [SerializeField] private List<ActionBase> _actions = new List<ActionBase>();
        [SerializeField] private List<Button> _buttons;

        private void Awake()
        {
            foreach (var button in _buttons)
                button.onClick.AddListener(RunActions);
        }

        private void RunActions()
        {
            foreach (var action in _actions)
            {
                action.Execute();
            }
        }
    }
}