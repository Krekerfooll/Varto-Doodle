using OIMOD.Core.Component;
using OIMOD.Core.GameMech;
using UnityEngine;

public class OI_PlatformDeadlySimple : OI_PlatformCore
{
    [SerializeField] private OI_CheckTargetsPositionY _checkTargetPosition;
    [SerializeField] private OI_CheckOnTriggerEnter _checkOnTriggerEnter;
    [SerializeField] private OI_DestroyAction _destroyAction;

    public override void Init(OI_GameData gameData)
    {
        base.Init(gameData);
        _checkTargetPosition._targetATransform = gameData.playerInstance.transform;
        _checkOnTriggerEnter._targetObject = gameData.playerInstance;
        _destroyAction._targetToDestroy = gameData.playerInstance;
    }
}
