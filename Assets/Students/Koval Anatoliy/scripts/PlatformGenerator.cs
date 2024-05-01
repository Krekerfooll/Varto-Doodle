using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [Header("Global Settings")]
    [Space]
    [SerializeField] private Transform _target;
    [Space]
    [Header("Spawn Settings")]
    [Space]
    [SerializeField] private ColliderSwitcher _platformPrefab;
    [SerializeField] private int _stepsCountToSpawn;
    [SerializeField] private int _stepHeight;
    [SerializeField] private Vector2 _bounds;
    [SerializeField] private float _stepsCountToDelete;
    private float _lastPlatformSpawnedOnPlayerPos;

    private void Awake()
    {
        _lastPlatformSpawnedOnPlayerPos = _target.position.y;

        for (int i = 0; i < _stepsCountToSpawn; i++)
        {
            SpawnPlatform(i + 1);
        }
    }

    private void Update()
    {
        if (_target.position.y - _lastPlatformSpawnedOnPlayerPos > _stepHeight)
        {
            SpawnPlatform(_stepsCountToSpawn);
            _lastPlatformSpawnedOnPlayerPos += _stepHeight;
        }
    }

    private void SpawnPlatform(int stepsCount)
    {
        var platformPositionX = Random.Range(_bounds.x, _bounds.y);
        var platformPositionY = _target.position.y + stepsCount * _stepHeight;

        var platformPosition = new Vector3(platformPositionX, platformPositionY, transform.position.z); 

        var spawnedPlatform = Instantiate(_platformPrefab, platformPosition, Quaternion.identity, this.transform);
        spawnedPlatform.GetComponent<ColliderSwitcher>().Init(_target); 
    }
}
