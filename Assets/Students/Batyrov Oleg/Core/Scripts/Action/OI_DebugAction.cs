using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_DebugAction : OI_ActionBase
    {
        protected override void ExecuteInternal()
        {
            Debug.Log("This action is executed!");
        }
    }
}