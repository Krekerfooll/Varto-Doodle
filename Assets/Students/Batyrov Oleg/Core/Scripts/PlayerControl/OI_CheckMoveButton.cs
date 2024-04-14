using System.Collections.Generic;
using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_CheckMoveButton : MonoBehaviour
    {
        [SerializeField] private OI_InputManager inputManager;
        [Space]
        [SerializeField] private List<OI_ActionBase> _moveActions;

        private void Update()
        {

            if (inputManager.MoveInput != 0)
            {
                foreach (var action in _moveActions)
                {
                    action.Execute();
                }
            }
        }
    }
}
