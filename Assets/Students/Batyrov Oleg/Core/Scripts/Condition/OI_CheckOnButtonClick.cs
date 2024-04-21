using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OIMOD.Core.Component
{
    public class OI_CheckOnButtonClick : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private List<OI_ActionBase> actions;

        private void Awake()
        {
            button.onClick.AddListener(ExecuteActions);
        }
        private void ExecuteActions()
        {
            foreach (var action in actions)
            {
                action.Execute();
            }
        }
    }
}