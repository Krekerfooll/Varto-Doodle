using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class PlatformData : ScriptableObject
    {
        [SerializeField] protected GameObject _objectPrefab;
        [SerializeField] protected PlatformType _platformType;
        [SerializeField] protected bool _colorChangeble;

        public virtual GameObject SpawnPlatform(GameObject Target, Vector2 SpawnedPosition, Transform Parent)
        {
            var _object = Instantiate(_objectPrefab, SpawnedPosition, Quaternion.identity, Parent);
            _object.GetComponent<ColorChangable>().CanChangeColor = _colorChangeble;
            _object.GetComponent<EnableCollider>().ColliderInit(Target.transform);
            return _object;
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