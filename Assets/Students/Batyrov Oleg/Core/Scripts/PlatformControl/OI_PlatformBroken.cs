using OIMOD.Core.GameMech;
using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_PlatformBroken : OI_PlatformCore
    {
        [SerializeField] private OI_CheckTargetsPositionY _checkTargetPosition;
        [SerializeField] private OI_CheckOnCollisionEnter _checkOnCollisionEnter;

        public override void Init(OI_GameData gameData)
        {
            base.Init(gameData);
            _checkTargetPosition._targetATransform = gameData.playerInstance.transform;
            _checkOnCollisionEnter._targetObject = gameData.playerInstance;
        }
    }
}

