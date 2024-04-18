using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public float spawnEmptyProbability = 0.2f;
    public GameObject startPlatform;
    public GameObject player;

    public float platformWidth = 2.5f;

    public int platformsInRow = 12;
    public int maxSpawnRows = 7;

    public int spawnRowCountTrigger = 2;

    public float horizontalSpawnDistance = 7f;

    private Queue<GameObject[]> _spawnedPlatforms;
    private int _rowsSpawned = 0;

    private Transform _startPlatfromTransform;
    private Transform _playerTransform;



    private void Awake()
    {
        _spawnedPlatforms = new Queue<GameObject[]>();
        _startPlatfromTransform = startPlatform.transform;
        _playerTransform = player.transform;



        for (int i = 0; i < maxSpawnRows; i++)
        {
            SpawnPlatformRow(i + 1);
            _rowsSpawned++;
        }
    }

    private GameObject getPlatformToSpawn()
    {
        float randomValue = UnityEngine.Random.value;
        for (int i = platformPrefabs.Length - 1; i >= 0; i--)
        {
            if(randomValue < platformPrefabs[i].GetComponent<PlatformBase>().spawnProbability)
            {
                return platformPrefabs[i];
            }
        }
        return platformPrefabs[0];
    }

    private void SpawnPlatformRow(int rowNumber, float offsetX = 0f)
    {
        var platformPositionY = _startPlatfromTransform.position.y + rowNumber * horizontalSpawnDistance;

        var offsetPlatfromX = Mathf.Round(offsetX / platformWidth);
        //Debug.Log($"offsetPlatfromX: {offsetPlatfromX}");
        //Debug.Log($"rowNumber: {rowNumber}");

        if(offsetPlatfromX != 0)
        {
            if(offsetPlatfromX % 2 != 0)
            {
                offsetPlatfromX--;
            }
        }

        //Debug.Log($"offsetPlatfromXProcessed: {offsetPlatfromX}");

        var startPlatformPositionX = _startPlatfromTransform.position.x - platformWidth * (platformsInRow / 2) * 2 + offsetPlatfromX * platformWidth;

        var isPrevPlatformSpawned = false;

        var platformGroup = new GameObject[platformsInRow];

        for (int i = 0;i < platformsInRow; i++) {

            if(isPrevPlatformSpawned)
            {
                if(UnityEngine.Random.value < spawnEmptyProbability) {
                    isPrevPlatformSpawned = false;
                    platformGroup[i] = null;
                    continue; 
                }
            }
            var platformPositionX = startPlatformPositionX + (i * 2) * platformWidth + platformWidth * (rowNumber % 2);

            var spawnedPlatform = Instantiate(getPlatformToSpawn(), new Vector3(platformPositionX, platformPositionY, transform.position.z), Quaternion.identity);
            isPrevPlatformSpawned = true;
            platformGroup[i] = spawnedPlatform;
        }
        _spawnedPlatforms.Enqueue(platformGroup);

    }

    void Update()
    {
        var _lastPlatformRowY = _startPlatfromTransform.position.y + _rowsSpawned * horizontalSpawnDistance;

        if ((_lastPlatformRowY - _playerTransform.position.y) / horizontalSpawnDistance < spawnRowCountTrigger)
        {
            _rowsSpawned++;
            SpawnPlatformRow(_rowsSpawned, _playerTransform.position.x - _startPlatfromTransform.position.x);
            var platformGroupToDelete = _spawnedPlatforms.Dequeue();

            for (int i = 0; i < platformGroupToDelete.Length; i++)
            {
                if (platformGroupToDelete[i] && platformGroupToDelete[i].gameObject)
                {
                    Destroy(platformGroupToDelete[i].gameObject);
                }
            }
        }
    }
}