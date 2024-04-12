using OIMOD.Core.Component;
using UnityEngine;

namespace OIMOD.Core.GameMech
{
    public class OI_PlatformSimple : OI_PlatformCore
    {
        [SerializeField] private OI_CheckTargetsPositionY _checkTargetPosition;

        public override void Init(OI_GameData gameData)
        {
            base.Init(gameData);
            _checkTargetPosition._targetATransform = gameData.playerInstance.transform;
        }
    }
}

