using Alokhin.Stanislav.PlatformGround;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Alokhin.Stanislav.PlatformGenerator
{
    public class PlatformGenerator : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [Space]
        [SerializeField] private Platforms _platformPrefab;
        [SerializeField] private int _stepsCountToSpawn;
        [SerializeField] private float _stepsCountToDelete;
        [SerializeField] private float _stepHeight;
        [SerializeField] private Vector2 _bounds;

        private Queue<Platforms> _spawnedPlatforms;

        private float _lastPlatformSpawnedOnPlayerPosition;
        private float _lastPlatformDeletedOnPlayerPosition;

        private void Awake()
        {
            _spawnedPlatforms = new Queue<Platforms>();

            _lastPlatformDeletedOnPlayerPosition = _lastPlatformSpawnedOnPlayerPosition = _target.position.y;

            for ( int i = 0; i < _stepsCountToSpawn; i++ )
            {
                SpawnPlatform(i + 1);
            }
        }
        private void Update()
        {
            if(_target.position.y - _lastPlatformSpawnedOnPlayerPosition > _stepHeight )
            {
                SpawnPlatform(_stepsCountToSpawn);
                _lastPlatformSpawnedOnPlayerPosition += _stepHeight;
            }
            if(_target.position.y - _lastPlatformDeletedOnPlayerPosition > _stepHeight * _stepsCountToDelete)
            {
                var platformToDelete = _spawnedPlatforms.Dequeue();

                if( platformToDelete && platformToDelete.gameObject)
                {
                    Destroy(platformToDelete.gameObject);
                }
                _lastPlatformDeletedOnPlayerPosition += _stepHeight;
            }
        }

        private void SpawnPlatform(int _stepsCount)
        {
            var platformPositionX = Random.Range(_bounds.x, _bounds.y);
            var platformPositionY = _target.position.y + _stepsCount * _stepHeight;

            var platformPosition = new Vector3(platformPositionX, platformPositionY, transform.position.z);

            var spawnPlatform = Instantiate(_platformPrefab,platformPosition,Quaternion.identity, this.transform);
            spawnPlatform.Init(_target);

            _spawnedPlatforms.Enqueue(spawnPlatform);
        }
    }
}

