using System.Collections.Generic;
using UnityEngine;

namespace RomanDoliba.Platform
{
    public class PlatformSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _platformTarget;
        [SerializeField] private List<Platform> _platformsTypes;
        [SerializeField] private Vector2Int _platformsOnOneHeight;
        [SerializeField] private int _stepsToSpawn;
        [SerializeField] private float _stepsToDelete;
        [SerializeField] private float _stepHeight;
        [SerializeField] private Vector2 _boundsX;
        [SerializeField] private Vector2 _boundsY;
        private Queue<Platform[]> _spawnedPlatforms;
        private float _lastPlatformsSpawnedPosition;
        private float _lastPlatformsDeletedPosition;

        private void Awake()
        {
            _spawnedPlatforms = new Queue<Platform[]>();

            _lastPlatformsDeletedPosition = _lastPlatformsSpawnedPosition = _platformTarget.position.y;
            for (int i = 0; i < _stepsToSpawn; i++)
            {
                SpawnPlatform(i + 1);
            }
        }

        private void Update()
        {
            if (_platformTarget.position.y - _lastPlatformsSpawnedPosition > _stepHeight)
            {
                SpawnPlatform(_stepsToSpawn);
                _lastPlatformsSpawnedPosition += _stepHeight;
            }
            if (_platformTarget.position.y - _lastPlatformsDeletedPosition > _stepHeight * _stepsToDelete)
            {
                var platformGroupToDelete = _spawnedPlatforms.Dequeue();
                for (int i = 0; i < platformGroupToDelete.Length; i++)
                {
                    if (platformGroupToDelete[i] && platformGroupToDelete[i].gameObject)
                    {
                        Destroy(platformGroupToDelete[i].gameObject);
                    }
                }

                _lastPlatformsDeletedPosition += _stepHeight;
            }
        }

        private void SpawnPlatform(int stepsCount)
        {
            var platformPositionY = 0f;
            var platformsToSpawnCount = Random.Range(_platformsOnOneHeight.x, _platformsOnOneHeight.y +1);
            var platformGroup = new Platform[platformsToSpawnCount];

            for(int i = 0; i < platformsToSpawnCount; i++)
            {
                    
                if (platformsToSpawnCount == 1)
                    {
                        platformPositionY = _platformTarget.position.y + stepsCount * _stepHeight;
                    }
                    else
                    {
                        var randomHeight = Random.Range(_boundsY.x, _boundsY.y);
                        platformPositionY = _platformTarget.position.y + randomHeight + stepsCount * _stepHeight;
                    }

                var platformPositionX = Random.Range(_boundsX.x, _boundsX.y);
                var platformPosition = new Vector3(platformPositionX, platformPositionY, _platformTarget.position.z);

                var randomPlatform = _platformsTypes[Random.Range(0, _platformsTypes.Count)];                        

                var spawnedPlatform = Instantiate(randomPlatform, platformPosition, Quaternion.identity, this.transform);
                spawnedPlatform.Init(_platformTarget);

                platformGroup[i] = spawnedPlatform;
            }
            _spawnedPlatforms.Enqueue(platformGroup);
        }
        
    }
}
