using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformGenerator : PlatformGeneratorBase
{
    [Header("Global Settings:")]
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject[] platformPrefabs;
    [SerializeField] private int platformsPerStep = 5;
    [SerializeField] private int stepsToSpawn = 3;
    [SerializeField] private int stepsToDelete = 5;
    [SerializeField] private float stepHeight = 3f;
    [SerializeField] private Vector2 spawnXBounds;

    private Queue<int> _groupsPlatformsCount = new Queue<int>();
    private float _lastPlatformsSpawnedOnPlayerPosition;
    private float _lastPlatformsDeletedOnPlayerPosition;
    protected override void InitGenerator()
    {
        _lastPlatformsSpawnedOnPlayerPosition = _target.position.y;
        _lastPlatformsDeletedOnPlayerPosition = _target.position.y;
        for (int i = 0; i < stepsToSpawn; i++)
        {
            SpawnPlatformsOnStep(i);
        }
    }

    protected override bool ShouldSpawn()
    {
        return _target.position.y - _lastPlatformsSpawnedOnPlayerPosition > stepHeight;
    }

    protected override bool ShouldDelete()
    {
        return _target.position.y - _lastPlatformsDeletedOnPlayerPosition > stepHeight * stepsToDelete;
    }

    protected override void SpawnPlatform()
    {
        SpawnPlatformsOnStep(stepsToSpawn);
        _lastPlatformsSpawnedOnPlayerPosition = _target.position.y;
    }

    protected override void DeletePlatform()
    {
        if (_groupsPlatformsCount.Count > 0)
        {
            int platformsToDelete = _groupsPlatformsCount.Dequeue();
            while (platformsToDelete-- > 0)
            {
                Destroy(platforms[0]);
                platforms.RemoveAt(0);
            }
        }
        _lastPlatformsDeletedOnPlayerPosition = _target.position.y;
    }

    private void SpawnPlatformsOnStep(int stepIndex)
    {
        for (int i = 0; i < platformsPerStep; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(spawnXBounds.x, spawnXBounds.y), _target.position.y + stepHeight * stepIndex, 0);
            GameObject platform = Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)], spawnPosition, Quaternion.identity);
            platforms.Add(platform);
        }
        _groupsPlatformsCount.Enqueue(platformsPerStep);
    }
}