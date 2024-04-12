using OIMOD.Core.Component;
using UnityEngine;

namespace OIMOD.Core.GameMech
{
    public abstract class OI_PlatformCore : MonoBehaviour
    {
        [Header("Base Setup")]
        [SerializeField] protected Collider2D _platformCollider;
        [SerializeField] protected GameObject _playerInstance;
        [SerializeField] protected GameObject _destroyBorder;
        [Header("TestOnly")]
        [SerializeField] protected bool _init;
        [Header("Scripts Setup")]
        [SerializeField] protected OI_CheckTargetDestroyPosition _checkDestroyPosition;

        public virtual void Init(OI_GameData gameData)
        {
            _playerInstance = gameData.playerInstance;
            _destroyBorder = gameData.levelBorderDown;

            _checkDestroyPosition._targetDestroyAtTransform = gameData.levelBorderDown.transform;

            _init = true;
        }
    }
}

