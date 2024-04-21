using UnityEngine;

namespace OIMOD.Core.Component
{
    public abstract class OI_PlatformCore : MonoBehaviour
    {
        [Header("Base Setup")]
        [SerializeField] protected OI_GameData _gameData;
        [SerializeField] protected Collider2D _platformCollider;
        protected GameObject _playerInstance;
        protected GameObject _destroyBorder;
        [Header("Scripts Setup")]
        [SerializeField] protected OI_CheckTargetDestroyPosition _checkDestroyPosition;
        [SerializeField] protected OI_PlatformSpawnCollectable _platformSpawnCollectable;
        [SerializeField] protected OI_CheckTargetsPositionY _checkTargetPositionY;
        [SerializeField] protected OI_CheckOnCollisionEnter[] _checkOnCollisionEnter;
        [SerializeField] protected OI_CheckOnTriggerEnterUpwards[] _checkOnTriggerEnterUpwards;

        public virtual void Init(OI_GameData gameData)
        {
            _playerInstance = gameData.playerInstance;
            _destroyBorder = gameData.levelBorderDown;
            _checkDestroyPosition._targetDestroyAtTransform = gameData.levelBorderDown.transform;

            if (_platformSpawnCollectable != null )
            {
                _platformSpawnCollectable.gameData = gameData;
                _platformSpawnCollectable.Execute();
            }
            if (_checkTargetPositionY != null)
                _checkTargetPositionY._targetATransform = gameData.playerInstance.transform;

            if (_checkOnCollisionEnter != null)
            {
                for (int i = 0;  i < _checkOnCollisionEnter.Length; i++)
                    _checkOnCollisionEnter[i]._targetObject = gameData.playerInstance;
            }
            if (_checkOnTriggerEnterUpwards != null)
            {
                for (int i = 0; i < _checkOnTriggerEnterUpwards.Length; i++)
                    _checkOnTriggerEnterUpwards[i]._targetObject = gameData.playerInstance;
            }
        }
        public void Awake()
        {
            if (_gameData != null) Init(_gameData);
        }
    }
}

