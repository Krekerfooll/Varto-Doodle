using System.Collections.Generic;
using UnityEngine;

namespace Varto.Examples.Platforms
{
    public class Varto_PlatformGenerator : MonoBehaviour
    {
        [Header("Global Settings:")]
        [Space]
        [SerializeField] private Transform _target;
        [Space]
        [Header("Spawn Settings:")]
        [Space]
        [SerializeField] private List<Varto_Platform> _platformPrefabVariants;
        [SerializeField] private Vector2Int _platformsSpawnedPerStepCount;
        [SerializeField] private int _stepsCountToSpawn;
        [SerializeField] private float _stepsCountToDelete;
        [SerializeField] private float _stepHeight;
        [SerializeField] private Vector2 _bounds;

        private Queue<Varto_Platform[]> _spawnedPlatforms;

        private float _lastPlatformsSpawnedOnPlayerPosition;
        private float _lastPlatformsDeletedOnPlayerPosition;

        private void Awake()
        {
            _spawnedPlatforms = new Queue<Varto_Platform[]>();

            _lastPlatformsDeletedOnPlayerPosition = _lastPlatformsSpawnedOnPlayerPosition = _target.position.y;

            for (int i = 0; i < _stepsCountToSpawn; i++)
            {
                SpawnPlatform(i + 1);
            }
        }

        private void Update()
        {
            if (_target.position.y - _lastPlatformsSpawnedOnPlayerPosition > _stepHeight)
            {
                SpawnPlatform(_stepsCountToSpawn);
                _lastPlatformsSpawnedOnPlayerPosition += _stepHeight;
            }

            if (_target.position.y - _lastPlatformsDeletedOnPlayerPosition > _stepHeight * _stepsCountToDelete)
            {
                var platformGroupToDelete = _spawnedPlatforms.Dequeue();

                for (int i = 0; i < platformGroupToDelete.Length; i++)
                {
                    if (platformGroupToDelete[i] && platformGroupToDelete[i].gameObject)
                    {
                        Destroy(platformGroupToDelete[i].gameObject);
                    }
                }

                _lastPlatformsDeletedOnPlayerPosition += _stepHeight;
            }
        }

        private void SpawnPlatform(int stepsCount)
        {
            var platformPositionY = _target.position.y + stepsCount * _stepHeight;

            var plaatformsToSpawnCount = Random.Range(_platformsSpawnedPerStepCount.x, _platformsSpawnedPerStepCount.y + 1);
            var platformGroup = new Varto_Platform[plaatformsToSpawnCount];

            for (int i = 0; i < plaatformsToSpawnCount; i++)
            {
                var platformPositionX = Random.Range(_bounds.x, _bounds.y);
                var platformPosition = new Vector3(platformPositionX, platformPositionY, transform.position.z);

                var randomPlatform = _platformPrefabVariants[Random.Range(0, _platformPrefabVariants.Count)];

                var spawnedPlatform = Instantiate(randomPlatform, platformPosition, Quaternion.identity, this.transform);
                spawnedPlatform.Init(_target);

                platformGroup[i] = spawnedPlatform;
            }
            
            _spawnedPlatforms.Enqueue(platformGroup);
        }
    }
}
