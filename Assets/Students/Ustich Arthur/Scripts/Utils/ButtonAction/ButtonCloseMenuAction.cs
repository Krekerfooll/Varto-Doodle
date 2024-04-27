using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class ButtonCloseMenuAction : ButtonActionBase
    {
        public override void ExecuteInternal()
        {
            DisableEnableObjects();
        }
    }
}