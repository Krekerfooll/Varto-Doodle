using Examples.Player;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDuplicator : MonoBehaviour
{
    [SerializeField] private PlatformTypeManager platformTypeManager;
    [SerializeField] private int maxPlatforms = 20;
    [SerializeField] private float spawnIntervalY = 2.0f;
    [SerializeField] private GameObject startObject;
    [SerializeField] private Vector2 _bounds; // Spawn boundaries along the X axis
    [SerializeField] private Vector2Int platformsPerSpawnRange = new Vector2Int(1, 3);  // Range of number of platforms per spawn
    [SerializeField] private float spawnIntervalX = 1.0f; // X-axis platform spacing

    private Queue<GameObject> activePlatforms = new Queue<GameObject>();
    private float _lastPlatformsSpawnedOnPlayerPosition;

    void Start()
    {
        if (startObject == null || platformTypeManager == null)
        {
            return;
        }

        activePlatforms = new Queue<GameObject>();
        _lastPlatformsSpawnedOnPlayerPosition = startObject.transform.position.y;

        while (activePlatforms.Count < maxPlatforms)
        {
            SpawnPlatforms(_lastPlatformsSpawnedOnPlayerPosition);
            _lastPlatformsSpawnedOnPlayerPosition += spawnIntervalY;
        }
    }

    void Update()
    {
        while (activePlatforms.Count > 0 && activePlatforms.Peek().transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize)
        {
            GameObject toDestroy = activePlatforms.Dequeue();
            Destroy(toDestroy);
        }

        if (activePlatforms.Count < maxPlatforms)
        {
            SpawnPlatforms(_lastPlatformsSpawnedOnPlayerPosition);
            _lastPlatformsSpawnedOnPlayerPosition += spawnIntervalY;
        }
    }

    void SpawnPlatforms(float newYPosition)
    {
        int platformsToSpawn = Random.Range(platformsPerSpawnRange.x, platformsPerSpawnRange.y + 1);
        float initialXPosition = Random.Range(_bounds.x, _bounds.y);

        for (int i = 0; i < platformsToSpawn; i++)
        {
            float platformPositionX = initialXPosition + i * spawnIntervalX;
            Vector3 newPlatformPosition = new Vector3(platformPositionX, newYPosition, 0);
            GameObject newPlatformPrefab = platformTypeManager.GetRandomPlatformPrefab();
            GameObject newPlatform = Instantiate(newPlatformPrefab, newPlatformPosition, Quaternion.identity, transform);

            // Check if BuffManager already exists on the platform
            BuffManager buffManager = newPlatform.GetComponent<BuffManager>();
            if (buffManager == null)
            {
                // If not, add it dynamically (only if needed)
                buffManager = newPlatform.AddComponent<BuffManager>();
            }

            // Assume buff spawns on the platform itself
            buffManager.target = newPlatform.transform;

            activePlatforms.Enqueue(newPlatform);
        }
    }
}