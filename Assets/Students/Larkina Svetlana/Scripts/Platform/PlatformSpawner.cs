using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab; 
    public float horizontalSpawnDistance = 4f; 
    public float verticalSpawnDistance = 2f; 
    public int maxPlatformsInRow = 4; 

    public int maxSpawnRows = 5;

    private int rowsSpawned = 0;


    void Update()
    {
        if( rowsSpawned <= maxSpawnRows) { 
        // spawn row 1
        Vector2 spawnPosition = platformPrefab.transform.position;
        spawnPosition += Vector2.up * verticalSpawnDistance * (rowsSpawned + 1);

        Vector2 leftSpawnPosition = spawnPosition;
        leftSpawnPosition += Vector2.left * horizontalSpawnDistance;
        for (int i = 0; i < maxPlatformsInRow / 2; i++)
        {
            Instantiate(platformPrefab, leftSpawnPosition, Quaternion.identity);
            leftSpawnPosition += Vector2.left * horizontalSpawnDistance;
        }

        Vector2 rightSpawnPosition = spawnPosition;
        rightSpawnPosition += Vector2.right * horizontalSpawnDistance;
        for (int i = 0; i < maxPlatformsInRow / 2; i++)
        {
            Instantiate(platformPrefab, rightSpawnPosition, Quaternion.identity);
            rightSpawnPosition += Vector2.right * horizontalSpawnDistance;
        }
        rowsSpawned++;
        }
    }
}