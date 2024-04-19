using System.Collections.Generic;
using UnityEngine;

namespace Doodle.Core
{
    internal class PlatformGenerator : MonoBehaviour
    {
        [Header("Global Settings")]
        [Space]
        [SerializeField] private Transform _target;
        [Space]

        [Header("Platform Spawn Settings")]
        [Space]
        [SerializeField] private Platform _platformPrefab;

        [SerializeField] private float _stepHeight;
        [SerializeField] private Vector2 _frameBoundsX;

        [SerializeField] private int _stepAmountToSpawn;
        [SerializeField] private int _stepAmountToDelete;

        private Queue<Platform> _spawnedPlatforms; 

        private float _lastPlatformSpawnedUnderPlayerPositionY;
        private float _lastPlatformDeletedUnderPlayerPositionY;

        private void Awake()
        {
            _spawnedPlatforms = new Queue<Platform>();

            _lastPlatformSpawnedUnderPlayerPositionY = _target.position.y;
            _lastPlatformDeletedUnderPlayerPositionY = _target.position.y;

            for (int i = 0; i < _stepAmountToSpawn; i++)
            {
                SpawnPlatform(i+1, _stepHeight, _frameBoundsX, _target, _platformPrefab);
            }
        }
        private void Update()
        {
            if (_target.position.y - _lastPlatformSpawnedUnderPlayerPositionY > _stepHeight)
            {
                SpawnPlatform(_stepAmountToSpawn, _stepHeight, _frameBoundsX, _target, _platformPrefab);
                _lastPlatformSpawnedUnderPlayerPositionY += _stepHeight;
            }

            if(_target.position.y - _lastPlatformDeletedUnderPlayerPositionY > _stepHeight * _stepAmountToDelete)
            {
                DeletePlatform();
                _lastPlatformDeletedUnderPlayerPositionY += _stepHeight;
            }
        }
        private void SpawnPlatform(int stepCount, float stepHeight, Vector2 frameBounds, Transform target, Platform platformPrefab)
        {
            var platformPosition = CalcPlatformSpawnPosition(stepCount, stepHeight, frameBounds, target);

            var spawnedPlatform = Instantiate(platformPrefab, platformPosition, Quaternion.identity, this.transform);
            spawnedPlatform.Init(target);

            _spawnedPlatforms.Enqueue(spawnedPlatform);
        }
        private Vector3 CalcPlatformSpawnPosition(int stepCount, float stepHeight, Vector2 frameBounds, Transform target)
        {
            var platformPositionX = Random.Range(frameBounds.x, frameBounds.y);
            var platformPositionY = target.position.y + stepCount * stepHeight;

            var platformPosition = new Vector3(platformPositionX, platformPositionY, transform.position.z);
            return platformPosition;
        }
        private void DeletePlatform()
        {
            var platformToDelete = _spawnedPlatforms.Dequeue();

            if(platformToDelete && platformToDelete.gameObject)
            {
                Destroy(platformToDelete.gameObject);
            }
        }
    }
}
