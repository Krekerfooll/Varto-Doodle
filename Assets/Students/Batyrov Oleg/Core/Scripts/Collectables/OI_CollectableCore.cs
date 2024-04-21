using UnityEngine;

namespace OIMOD.Core.Component
{
    public abstract class OI_CollectableCore : MonoBehaviour
    {
        [Header("Base Setup")]
        [SerializeField] protected GameObject _playerInstance;
        [SerializeField] protected GameObject _destroyBorder;
        [Space]
        [Header("TestOnly")]
        [SerializeField] protected bool _init;
        [Header("Scripts Setup")]
        [SerializeField] public OI_GameData _gameData;
        [SerializeField] protected OI_CheckTargetDestroyPosition _checkDestroyPosition;
        [SerializeField] protected OI_CheckOnTriggerEnter _checkOnTriggerEnter;
        [SerializeField] protected OI_SpawnObjectAction _spawnObjectAction;

        public virtual void Init(OI_GameData gameData)
        {
            _playerInstance = gameData.playerInstance;
            _destroyBorder = gameData.levelBorderDown;

            _checkDestroyPosition._targetDestroyAtTransform = gameData.levelBorderDown.transform;
            _checkOnTriggerEnter._targetObject = gameData.playerInstance;
            _gameData = gameData;

            if (_spawnObjectAction != null) 
                _spawnObjectAction.spawnPlaceholder = gameData.collectablePlaceholder.transform;

            _init = true;
        }
    }
}