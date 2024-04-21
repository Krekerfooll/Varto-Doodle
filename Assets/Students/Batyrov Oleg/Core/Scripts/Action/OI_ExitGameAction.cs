using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_ExitGameAction : OI_ActionBase
    {
        protected override void ExecuteInternal()
        {
            Application.Quit();
        }
    }
}