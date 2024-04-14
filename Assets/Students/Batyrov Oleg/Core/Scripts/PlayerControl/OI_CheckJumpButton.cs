using System.Collections.Generic;
using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_CheckJumpButton : MonoBehaviour
    {
        [SerializeField] private OI_InputManager inputManager;
        [Space]
        [SerializeField] private List<OI_ActionBase> _jumpActions;

        private void Update()
        {

            if (inputManager.JumpInput)
            {
                foreach (var action in _jumpActions)
                {
                    action.Execute();
                }
            }
        }
    }
}

