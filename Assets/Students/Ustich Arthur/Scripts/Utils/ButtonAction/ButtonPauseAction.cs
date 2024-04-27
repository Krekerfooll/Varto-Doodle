using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class ButtonPauseAction : ButtonActionBase
    {
        public override void ExecuteInternal()
        {
            DisableEnableObjects();
        }
    }
}