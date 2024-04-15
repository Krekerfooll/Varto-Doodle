
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformsGenerator : GeneratorBase
{

    [Header("Global Settings:")]
    [Space]
    [SerializeField] private Transform _target;
    [Space]
    [Header("Spawn Settings:")]
    [Space]
    [SerializeField] private List<Platform> _platformPrefabVariants;
    [SerializeField] private Vector2Int _platformsSpawnedPerStepCount;
    [SerializeField] private int _stepsCountToSpawn;
    [SerializeField] private float _stepsCountToDelete;
    [SerializeField] private float _stepHeight;
    [SerializeField] private Vector2 _bounds;

    private Queue<int> _groupsPlatformsCount;

    private float _lastPlatformsSpawnedOnPlayerPosition;
    private float _lastPlatformsDeletedOnPlayerPosition;

    protected override void InitGenerator()
    {
        _groupsPlatformsCount = new Queue<int>();

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
        var isAbleToDeletePlatformByPlayerPosition = _target.position.y - _lastPlatformsDeletedOnPlayerPosition > _stepHeight * _stepsCountToDelete;
        return isHasPlatforms && isAbleToDeletePlatformByPlayerPosition;
    }

    protected override void SpawnPlatforms()
    {
        SpawnPlatform(_stepsCountToSpawn);
        _lastPlatformsSpawnedOnPlayerPosition += _stepHeight;
    }
    protected override void DeletePlatforms()
    {
        var groupToDeletePlatformsCount = _groupsPlatformsCount.Dequeue();

        var platformsToDestroy = SpawnedPlatforms.Take(groupToDeletePlatformsCount);

        foreach (var platform in platformsToDestroy)
        {
            if (platform && platform.gameObject)
            {
                Destroy(platform.gameObject);
            }
        }

        SpawnedPlatforms.RemoveRange(0, groupToDeletePlatformsCount);

        _lastPlatformsDeletedOnPlayerPosition += _stepHeight;
    }

    private void SpawnPlatform(int stepsCount)
    {
        var platformPositionY = _target.position.y + stepsCount * _stepHeight;

        var platformsToSpawnCount = Random.Range(_platformsSpawnedPerStepCount.x, _platformsSpawnedPerStepCount.y + 1);

        for (int i = 0; i < platformsToSpawnCount; i++)
        {
            var platformPositionX = Random.Range(_bounds.x, _bounds.y);
            var platformPosition = new Vector3(platformPositionX, platformPositionY, transform.position.z);

            Collider2D[] colliders = Physics2D.OverlapBoxAll(platformPosition, Vector2.one * 0.5f, 0);

            if (colliders.Length == 0)
            {
                var randomPlatform = _platformPrefabVariants[Random.Range(0, _platformPrefabVariants.Count)];
                var spawnedPlatform = Instantiate(randomPlatform, platformPosition, Quaternion.identity, this.transform);
                spawnedPlatform.Init(_target);
                SpawnedPlatforms.Add(spawnedPlatform);
            }
            else
            {

                Debug.Log("Collisions detected, trying another position...");
                i--;
            }
        }

        _groupsPlatformsCount.Enqueue(platformsToSpawnCount);
    }
}
