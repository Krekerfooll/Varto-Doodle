using System.Linq;
using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Platforms
{
    public class PlatformGenerator : BaseGenerator
    {
        [Header("Player Platform Initializer target")]
        [SerializeField] protected Transform _target;
        [SerializeField] protected Platform _platformPrefab;
        [SerializeField] private int _stepsCountToSpawn;
        [SerializeField] private int _stepsCountToDelete;
        [SerializeField] private float _stepHeight;
        [SerializeField] private Vector2 _bounds;

        protected float _lastPlatformsSpawnedOnPlayerPosition;
        protected float _lastPlatformsDeletedOnPlayerPosition;

        protected override void InitGenerator()
        {
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
            var isAbleToPlatformsOnPlayerPosition = _target.position.y - _lastPlatformsDeletedOnPlayerPosition >
                                                    _stepHeight * _stepsCountToDelete;
            return isHasPlatforms && isAbleToPlatformsOnPlayerPosition;
        }

        protected override void SpawnPlatforms()
        {
            SpawnPlatform(_stepsCountToSpawn);
            _lastPlatformsSpawnedOnPlayerPosition += _stepHeight;
        }

        protected override void DeletePlatforms()
        {
            var platformToDelete = SpawnedPlatforms.First();
            SpawnedPlatforms.Remove(platformToDelete);

            if (platformToDelete && platformToDelete.gameObject)
            {
                Destroy(platformToDelete.gameObject);
            }

            _lastPlatformsDeletedOnPlayerPosition += _stepHeight;
        }

        private void SpawnPlatform(int stepsCount)
        {
            var platformPositionX = Random.Range(_bounds.x, _bounds.y);
            var platformPositionY = _target.position.y + stepsCount * _stepHeight;

            var platformPosition = new Vector3(platformPositionX, platformPositionY, transform.position.z);

            var spawnedPlatform = Instantiate(_platformPrefab, platformPosition, Quaternion.identity, this.transform);
            spawnedPlatform.Init(_target);
            
            SpawnedPlatforms.Add(spawnedPlatform);
        }

    }
    
}
