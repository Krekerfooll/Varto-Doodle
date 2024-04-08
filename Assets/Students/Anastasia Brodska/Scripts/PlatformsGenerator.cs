using System.Collections.Generic;
using UnityEngine;
using Varto.Examples.Platforms;

public class PlatformsGenerator : MonoBehaviour
{
    [Header("Global Settings:")]
    [SerializeField] private Transform _target;
    [Space]

    [Header("Spawn Settings:")]
    [SerializeField] private PlatformCollider _platformPrefab;
    [SerializeField] private int _stepsCountToSpawn;
    [SerializeField] private float _stepsCountToDelete;
    [SerializeField] private float _stepHeight;
    [SerializeField] private Vector2 _bounds;

    private Queue<PlatformCollider> _spawnedPlatforms;

    private float _lastPlatformsSpawnedOnPlayerPosition;
    private float _lastPlatformsDeletedOnPlayerPosition;

    private void Awake()
    {
        _spawnedPlatforms = new Queue<PlatformCollider>();

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
            var platformToDelete = _spawnedPlatforms.Dequeue();

            if (platformToDelete && platformToDelete.gameObject)
            {
                Destroy(platformToDelete.gameObject);
            }

            _lastPlatformsDeletedOnPlayerPosition += _stepHeight;
        }
    }

    private void SpawnPlatform(int stepsCount)
    {
        var platformPositionX = Random.Range(_bounds.x, _bounds.y);
        var platformPositionY = _target.position.y + stepsCount * _stepHeight;

        var platformPosition = new Vector3(platformPositionX, platformPositionY, transform.position.z);

        var spawnedPlatform = Instantiate(_platformPrefab, platformPosition, Quaternion.identity, this.transform);
        spawnedPlatform.Init(_target);

        _spawnedPlatforms.Enqueue(spawnedPlatform);
    }
}
