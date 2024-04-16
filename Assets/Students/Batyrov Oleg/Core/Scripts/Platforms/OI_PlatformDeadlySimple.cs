using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_PlatformDeadlySimple : OI_PlatformCore
    {
        [SerializeField] public OI_SendDestroyValueAction _sendDestroyValue;
        public override void Init(OI_GameData gameData)
        {
            base.Init(gameData);
            _sendDestroyValue.gameData = gameData;
        }
    }
}

