using System.Runtime.InteropServices;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    [CreateAssetMenu(fileName = "PlatformMoved", menuName = "Ustich/PlatformType/PlatformMoved", order = 2)]
    public class PlatformMoved : PlatformData
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private bool _moveRight;
        [SerializeField] private GameSettingsManager _gameSettingsManager;

        public override GameObject SpawnPlatform(GameObject Target, Vector2 SpawnedPosition, Transform Parent)
        {
            var _object = Instantiate(_objectPrefab, SpawnedPosition, Quaternion.identity, Parent);
            _object.GetComponent<ColorChangable>().CanChangeColor = _colorChangeble;
            _object.GetComponent<EnableCollider>().ColliderInit(Target.transform);
            AddMovedPlatform(ref _object);
            return _object;
        }

        private void AddMovedPlatform(ref GameObject gameObject)
        {
            if (gameObject.GetComponent<MovedPlatform>() == null)
                gameObject.AddComponent<MovedPlatform>();

            gameObject.GetComponent<MovedPlatform>().Init(_gameSettingsManager);
            gameObject.GetComponent<MovedPlatform>().MoveSpeed = _moveSpeed;
            gameObject.GetComponent<MovedPlatform>().MoveRight = _moveRight;
        }
    }
}