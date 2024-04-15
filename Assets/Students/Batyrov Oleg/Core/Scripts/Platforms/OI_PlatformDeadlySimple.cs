using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_PlatformDeadlySimple : OI_PlatformCore
    {
        [SerializeField] private OI_DestroyAction _destroyAction;

        public override void Init(OI_GameData gameData)
        {
            base.Init(gameData);

            _destroyAction._targetToDestroy = gameData.playerInstance;
        }
    }
}

