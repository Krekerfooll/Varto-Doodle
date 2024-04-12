using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Platforms
{
    public class PlatformGenerator : BaseGenerator
    {
        [Header("Global Settings:")]
        [Space]
        [SerializeField] private Transform _target;
        [Space]
        [Header("Spawn Settings:")]
        [Space]
        [SerializeField] private List<Platform> _platformPrefabVariants;
        [SerializeField] private Vector2Int _platformsSpawnedPerStepCount;
        [SerializeField] private int _stepsCountToSpawn;
        [SerializeField] private float _stepsCountToDelete;
        [SerializeField] private float _stepHeight;
        [SerializeField] private Vector2 _bounds;
        [SerializeField] private float _setOffsetY;

        private Queue<int> _groupsPlatformsCount;

        private float _lastPlatformsSpawnedOnPlayerPosition;
        private float _lastPlatformsDeletedOnPlayerPosition;

        protected override void InitGenerator()
        {
            _groupsPlatformsCount = new Queue<int>();

            _lastPlatformsDeletedOnPlayerPosition = _lastPlatformsSpawnedOnPlayerPosition = _target.position.y;

            for (int i = 0; i < _stepsCountToSpawn; i++)
            {
                SpawnPlatform(i + 1);
            }
        }

        protected override bool IsCanSpawnPlatforms()
        {
            return _target.position.y - _lastPlatformsSpawnedOnPlayerPosition > _stepHeight;
        }
        protected override bool IsCanDeletePlatforms()
        {
            var isHasPlatforms = SpawnedPlatforms.Count > 0;
            var isAbleToDeletePlatformByPlayerPosition = _target.position.y - _lastPlatformsDeletedOnPlayerPosition > _stepHeight * _stepsCountToDelete;
            return isHasPlatforms && isAbleToDeletePlatformByPlayerPosition;
        }

        protected override void SpawnPlatforms()
        {
            SpawnPlatform(_stepsCountToSpawn);
            _lastPlatformsSpawnedOnPlayerPosition += _stepHeight;
        }
        protected override void DeletePlatforms()
        {
            var groupToDeletePlatformsCount = _groupsPlatformsCount.Dequeue();

            var platformsToDestroy = SpawnedPlatforms.Take(groupToDeletePlatformsCount);

            foreach (var platform in platformsToDestroy)
            {
                if (platform && platform.gameObject)
                {
                    Destroy(platform.gameObject);
                }
            }

            SpawnedPlatforms.RemoveRange(0, groupToDeletePlatformsCount);

            _lastPlatformsDeletedOnPlayerPosition += _stepHeight;
        }

        private void SpawnPlatform(int stepsCount)
        {
            var platformPositionY = _target.position.y + stepsCount * _stepHeight;

            var platformsToSpawnCount = Random.Range(_platformsSpawnedPerStepCount.x, _platformsSpawnedPerStepCount.y + 1);
            var columnWidth = (_bounds.y - _bounds.x) / platformsToSpawnCount;
            
            for (int i = 0; i < platformsToSpawnCount; i++)
            {
                var columnStart = _bounds.x + i * columnWidth;
                var columnEnd = columnStart + columnWidth;
                
                var platformPositionX = Random.Range(columnStart, columnEnd);
                var randomYOffset = Random.Range(-1, 2) * _setOffsetY;
                var platformPosition = new Vector3(platformPositionX, platformPositionY  + randomYOffset, transform.position.z);

                var randomPlatform = _platformPrefabVariants[Random.Range(0, _platformPrefabVariants.Count)];

                var spawnedPlatform = Instantiate(randomPlatform, platformPosition, Quaternion.identity, this.transform);
                spawnedPlatform.Init(_target);

                SpawnedPlatforms.Add(spawnedPlatform);
            }

            _groupsPlatformsCount.Enqueue(platformsToSpawnCount);
        }
    }
    
}
