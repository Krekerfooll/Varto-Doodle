using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Artur.Pashchenko.Platform
{
    public class SimplePlatformGenerator : MonoBehaviour
    {
        [Header("Main Settings")]
        [Space]
        [SerializeField] private Transform _target;
        [Space]
        [Header("Spawn Settings")]
        [Space]
        [SerializeField] private Platform _platformPrefab;
        [SerializeField] private int _stepsToSpawn;
        [SerializeField] private float _stepsToDelete;
        [SerializeField] private float _stepHeight;
        [SerializeField] private Vector2 _border;

        private Queue<Platform> _spawnedPlatforms = new Queue<Platform>();

        private float _lastPlatformsSpawnedOnPlayerPos;
        private float _lastPlatformsDeletedOnPlayerPos;


        private void Awake()
        {
            _lastPlatformsSpawnedOnPlayerPos = _target.position.y;
            _lastPlatformsDeletedOnPlayerPos = _target.position.y;



            for (int i = 0; i < _stepsToSpawn; i++)
            {
                SpawnPlatform(i + 1);
            }
        }
        private void Update()
        {
            if (_target.position.y - _lastPlatformsSpawnedOnPlayerPos > _stepHeight)
            {
                SpawnPlatform(_stepsToSpawn);
                _lastPlatformsSpawnedOnPlayerPos += _stepHeight;
            }

            if (_target.position.y - _lastPlatformsDeletedOnPlayerPos > _stepHeight * _stepsToDelete)
            {
                var platformToDelete = _spawnedPlatforms.Dequeue();

                if (platformToDelete)
                {
                    Destroy(platformToDelete.gameObject);
                }
                _lastPlatformsDeletedOnPlayerPos += _stepHeight;

            }


        }
            private void SpawnPlatform(int stepsCount)
            {
                var X = Random.Range(_border.x, _border.y);
                var Y = _target.position.y + stepsCount * _stepHeight;

                var platformPosition = new Vector3(X, Y, transform.position.z);
                var spawnedPlatform = Instantiate(_platformPrefab, platformPosition, Quaternion.identity, transform);

                spawnedPlatform.Init(_target);

                _spawnedPlatforms.Enqueue(spawnedPlatform);
            }
        }
    } 
