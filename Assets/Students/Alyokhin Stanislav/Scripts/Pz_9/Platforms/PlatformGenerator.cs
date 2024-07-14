using Alokhin.Stanislav.PlatformGround;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Alokhin.Stanislav.Platforms
{
    public class PlatformGenerator : PlatformGeneratorBase
    {
        [Header("Global Settings:")]
        [Space]
        [SerializeField] private Transform _target;
        [Space]
        [SerializeField] private List<Platforms> _platformPrefab;
        [SerializeField] private Vector2Int _platformsSpawnedPerStepCount;
        [SerializeField] private int _stepsCountToSpawn;
        [SerializeField] private float _stepsCountToDelete;
        [SerializeField] private float _stepHeight;
        [SerializeField] private Vector2 _bounds;

        private Queue<int> _groupsSpawnedPlatforms;

        private float _lastPlatformSpawnedOnPlayerPosition;
        private float _lastPlatformDeletedOnPlayerPosition;

        protected override void InitGenerator()
        {
            _groupsSpawnedPlatforms = new Queue<int>();

            _lastPlatformDeletedOnPlayerPosition = _lastPlatformSpawnedOnPlayerPosition = _target.position.y;

            for (int i = 0; i < _stepsCountToSpawn; i++)
            {
                SpawnPlatform(i + 1);
            }
        }
        protected override bool IsCanSpawnPlatforms()
        {
            return _target != null && _target.position.y - _lastPlatformSpawnedOnPlayerPosition > _stepHeight;
        }
        protected override bool IsCanDeletePlatforms()
        {
            var isHasPlatfoms = SpawnedPlatforms.Count > 0;
            var isAbleToDeletePlatformByPlayerPosition =
                _target != null && _target.position.y - _lastPlatformDeletedOnPlayerPosition > _stepHeight * _stepsCountToDelete;
            return isHasPlatfoms && isAbleToDeletePlatformByPlayerPosition;
        }
        protected override void SpawnPlatforms()
        {
            SpawnPlatform(_stepsCountToSpawn);
            _lastPlatformSpawnedOnPlayerPosition += _stepHeight;
        }
        protected override void DeletePlatforms()
        {
            var groupToDeletePlatformsCount = _groupsSpawnedPlatforms.Dequeue();
            var platformsDestroy = SpawnedPlatforms.Take(groupToDeletePlatformsCount);
            foreach (var platform in platformsDestroy)
            {
                if (platform && platform.gameObject)
                {
                    Destroy(platform.gameObject);
                }
            }
            SpawnedPlatforms.RemoveRange(0, groupToDeletePlatformsCount);
            _lastPlatformDeletedOnPlayerPosition += _stepHeight;
        }
        private void SpawnPlatform(int stepsCount)
        {
            var platformPositionY = _target.position.y + stepsCount * _stepHeight;

            var platformsToSpawnCount = Random.Range(_platformsSpawnedPerStepCount.x, _platformsSpawnedPerStepCount.y + 1);

            for (int i = 0; i < platformsToSpawnCount; i++)
            {
                var platformPositionX = Random.Range(_bounds.x, _bounds.y);
                var platformPosition = new Vector3(platformPositionX, platformPositionY, transform.position.z);

                var randomPlatform = _platformPrefab[Random.Range(0, _platformPrefab.Count)];

                var spawnedPlatform = Instantiate(randomPlatform, platformPosition, Quaternion.identity, this.transform);
                spawnedPlatform.Init(_target);

                SpawnedPlatforms.Add(spawnedPlatform);
            }

            _groupsSpawnedPlatforms.Enqueue(platformsToSpawnCount);
        }


    }
}

// private void Awake()
// {
//     _spawnedPlatforms = new Queue<Platforms>();
//
//     _lastPlatformDeletedOnPlayerPosition = _lastPlatformSpawnedOnPlayerPosition = _target.position.y;
//
//     for ( int i = 0; i < _stepsCountToSpawn; i++ )
//     {
//         SpawnPlatform(i + 1);
//     }
// }
//  private void Update()
//  {
//      if(_target.position.y - _lastPlatformSpawnedOnPlayerPosition > _stepHeight )
//      {
//          SpawnPlatform(_stepsCountToSpawn);
//          _lastPlatformSpawnedOnPlayerPosition += _stepHeight;
//      }
//      if(_target.position.y - _lastPlatformDeletedOnPlayerPosition > _stepHeight * _stepsCountToDelete)
//      {
//          var platformToDelete = _spawnedPlatforms.Dequeue();
//
//          if( platformToDelete && platformToDelete.gameObject)
//          {
//              Destroy(platformToDelete.gameObject);
//          }
//          _lastPlatformDeletedOnPlayerPosition += _stepHeight;
//      }
//  }

//  private void SpawnPlatform(int _stepsCount)
//  {
//      var platformPositionX = Random.Range(_bounds.x, _bounds.y);
//      var platformPositionY = _target.position.y + _stepsCount * _stepHeight;
//
//      var platformPosition = new Vector3(platformPositionX, platformPositionY, transform.position.z);
//
//      var spawnPlatform = Instantiate(_platformPrefab,platformPosition,Quaternion.identity, this.transform);
//      spawnPlatform.Init(_target);
//
//      _spawnedPlatforms.Enqueue(spawnPlatform);
//  }