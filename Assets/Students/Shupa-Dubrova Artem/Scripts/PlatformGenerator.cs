using System.Collections.Generic;
using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts
{
    public class PlatformGenerator : MonoBehaviour
    {
        [Space]
        [SerializeField] private Transform _target;
        [Space]
        [SerializeField] private List<Platforms> _platformPrefabVariants;
        [SerializeField] private Vector2Int _platformsSpawnedPerStepCount;
        [SerializeField] private int _stepsCountToSpawn;
        [SerializeField] private float _stepsCountToDelete;
        [SerializeField] private float _stepHeight;
        [SerializeField] private Vector2 _bounds;
        [SerializeField] private Vector2 _xOffset;
        [SerializeField] private Vector2 _yOffset;
        private Queue<Platforms[]> _spawnedPlatforms;

        private float _lastPlatformsSpawnedOnPlayerPosition;
        private float _lastPlatformsDeletedOnPlayerPosition;

        private void Awake()
        {
            _spawnedPlatforms = new Queue<Platforms[]>();

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

            var platformsToSpawnCount = Random.Range(_platformsSpawnedPerStepCount.x, _platformsSpawnedPerStepCount.y + 1);
            var platformGroup = new Platforms[platformsToSpawnCount];

            for (int i = 0; i < platformsToSpawnCount; i++)
            {
                var platformPositionX = Random.Range(_bounds.x, _bounds.y);
                var positionXOffset = Random.Range(_xOffset.x, _xOffset.y);
                var positionYOffset = Random.Range(_yOffset.x, _yOffset.y);
                var platformPosition = new Vector3(platformPositionX + positionXOffset, platformPositionY + positionYOffset, transform.position.z);

                var randomPlatform = _platformPrefabVariants[Random.Range(0, _platformPrefabVariants.Count)];

                var spawnedPlatform = Instantiate(randomPlatform, platformPosition, Quaternion.identity, this.transform);
                spawnedPlatform.Init(_target);

                platformGroup[i] = spawnedPlatform;
            }
            
            _spawnedPlatforms.Enqueue(platformGroup);
        }
    }
    
}
