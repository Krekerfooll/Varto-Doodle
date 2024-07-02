using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    [CreateAssetMenu(fileName = "PlatformWithSpawner", menuName = "Ustich/PlatformType/PlatformWithSpawner", order = 3)]
    public class PlatformWithSpawner : PlatformData
    {
        [Space]
        [Header("Action Spawn on Platform Configuration")]
        [SerializeField] private GameObject _spawnedObject;
        [SerializeField] private bool _executeOnAwake;

        public override GameObject SpawnPlatform(GameObject Target, Vector2 SpawnedPosition, Transform Parent)
        {
            var _object = Instantiate(_objectPrefab, SpawnedPosition, Quaternion.identity, Parent);
            _object.GetComponent<ColorChangable>().CanChangeColor = _colorChangeble;
            _object.GetComponent<EnableCollider>().ColliderInit(Target.transform);
            AddActionSpawnOnPlatform(ref _object);
            return _object;
        }

        private void AddActionSpawnOnPlatform(ref GameObject gameObject)
        {
            if (gameObject.GetComponent<ActionBaseSpawnOnPlatfowm>() == null)
                gameObject.AddComponent<ActionBaseSpawnOnPlatfowm>();

            gameObject.GetComponent<ActionBaseSpawnOnPlatfowm>().ExecuteOnAwake = _executeOnAwake;
            gameObject.GetComponent<ActionBaseSpawnOnPlatfowm>().ObjectPrefab = _spawnedObject;
            gameObject.GetComponent<ActionBaseSpawnOnPlatfowm>().Execute();
        }
    }
}