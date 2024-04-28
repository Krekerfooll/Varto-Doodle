using Artur.Pashchenko.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Artur.Pashchenko.Platform
{
    public class SimplePlatformGenerator : MonoBehaviour
    {
        [Header("Main Settings")]
        [Space]
        [SerializeField] private PlayerData _playerData;
        [Space]
        [Header("Spawn Settings")]
        [Space]
        [SerializeField] private Platform _platformPrefab;
        [SerializeField] private Platform _destroyablePlatformPrefab;
        [SerializeField] private int _stepsToSpawn;
        [SerializeField] private float _stepsToDelete;
        [SerializeField] private float _stepHeight;
        [SerializeField] private Vector2 _border;
        [SerializeField] private Vector2 _range;
        [SerializeField] private float _probabilityForType1;
        private Queue<Platform> _spawnedPlatforms = new Queue<Platform>();
        private float _lastPlatformsSpawnedOnPlayerPos;
        private float _lastPlatformsDeletedOnPlayerPos;


        private void Awake()
        {
            _lastPlatformsSpawnedOnPlayerPos = _playerData._targetPlatform.transform.position.y;
            _lastPlatformsDeletedOnPlayerPos = _playerData._targetPlatform.transform.position.y;



            for (int i = 0; i < _stepsToSpawn; i++)
            {
                SpawnPlatform(i + 1);
            }
        }
        private void Update()
        {
            if (_playerData._targetPlatform.transform.position.y - _lastPlatformsSpawnedOnPlayerPos > _stepHeight)
            {
                SpawnPlatform(_stepsToSpawn);
                _lastPlatformsSpawnedOnPlayerPos += _stepHeight;
            }

            if (_playerData._targetPlatform.transform.position.y - _lastPlatformsDeletedOnPlayerPos > _stepHeight * _stepsToDelete)
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
                var Y = _playerData._targetPlatform.transform.position.y + stepsCount * _stepHeight + Random.Range(_range.x, _range.y);

                var platformPosition = new Vector3(X, Y, transform.position.z);
                Platform selectedPlatformPrefab = Random.Range(0f, 100f) < _probabilityForType1 ? _platformPrefab : _destroyablePlatformPrefab;

                var spawnedPlatform = Instantiate(selectedPlatformPrefab, platformPosition, Quaternion.identity, transform);

                spawnedPlatform.Init(_playerData);

                _spawnedPlatforms.Enqueue(spawnedPlatform);
            }
        }
    } 
