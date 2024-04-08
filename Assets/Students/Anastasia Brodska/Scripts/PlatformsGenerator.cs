using System.Collections.Generic;
using UnityEngine;

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
            SpawnPlatform();
        }
    }

    private void Update()
    {
        if (_target.position.y - _lastPlatformsDeletedOnPlayerPosition > _stepHeight * _stepsCountToDelete)
        {
            if (_spawnedPlatforms.Count > 0)
            {
                var platformToDelete = _spawnedPlatforms.Dequeue();

                if (platformToDelete && platformToDelete.gameObject)
                {
                    Destroy(platformToDelete.gameObject);
                }

                _lastPlatformsDeletedOnPlayerPosition += _stepHeight;
            }
            else
            {
                Debug.LogWarning("No platforms to delete.");
            }
        }

        if (_target.position.y > _lastPlatformsSpawnedOnPlayerPosition)
        {
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        var platformPositionX = Random.Range(_bounds.x, _bounds.y);
        var platformPositionY = _lastPlatformsSpawnedOnPlayerPosition + _stepHeight;

        var platformPosition = new Vector3(platformPositionX, platformPositionY, transform.position.z);

        var spawnedPlatform = Instantiate(_platformPrefab, platformPosition, Quaternion.identity, this.transform);
        spawnedPlatform.Init(_target);

        _spawnedPlatforms.Enqueue(spawnedPlatform);

        _lastPlatformsSpawnedOnPlayerPosition = platformPositionY;
    }
}
