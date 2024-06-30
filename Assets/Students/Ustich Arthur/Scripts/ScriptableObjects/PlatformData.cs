using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    [CreateAssetMenu(fileName = "PlatformType", menuName = "Ustich/PlatformType", order = 1)]
    public class PlatformData : ScriptableObject
    {
        [SerializeField] private GameObject _objectPrefab;
        [SerializeField] private PlatformType _platformType;
        [SerializeField] private ExecutorBaseSO _executorBaseSO;
        [SerializeField] private Vector3 _position;
        [SerializeField] private Sprite _sprite;

        public TestStruct SpawnPrefab()
        {
            var SpawnedGameObject = Instantiate(_objectPrefab, _position, Quaternion.identity);
            return new TestStruct(_sprite, SpawnedGameObject, _platformType);
        }

        [System.Serializable]
        public struct TestStruct
        {
            public readonly Sprite _sprite;
            public readonly GameObject _gameObject;
            public readonly PlatformType _platformType;

            public TestStruct (Sprite sprite, GameObject gameObject, PlatformType platformType)
            {
                _sprite = sprite;
                _gameObject = gameObject;
                _platformType = platformType;
            }
        }
    }
}