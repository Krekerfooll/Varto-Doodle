using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_SendDestroyValueAction : OI_ActionBase
    {
        [SerializeField] public OI_GameData gameData;
        protected override void ExecuteInternal()
        {
            gameData.playerIsAlive = false;
        }
    }
}

