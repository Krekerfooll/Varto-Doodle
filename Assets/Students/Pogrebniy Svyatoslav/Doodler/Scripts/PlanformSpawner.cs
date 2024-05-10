 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
// using Varto.Examples.Platforms;
// using static UnityEngine.GraphicsBuffer;
// using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private float _platformHeight;
    [SerializeField] private Vector2 _platformEdges;
    [SerializeField] private List<GameObject> _prefabPlatformVariats;
    [SerializeField] private GameObject _Platform;
    [SerializeField] private Transform _target;
    [SerializeField] private int _platformsCount;
    [SerializeField] private float _positionSpawnY = -5;
    [SerializeField] private float _positionTriggerSpawn;
    [SerializeField] private float _positionTriggerDestroy;

    private Queue<GameObject> _spawnedPlatforms;

    private void Start()
    {
        _spawnedPlatforms = new Queue<GameObject>();
        var spawnedPlatform = Instantiate(_Platform, new Vector3(0, _positionSpawnY, 0), Quaternion.identity);
        _spawnedPlatforms.Enqueue(spawnedPlatform);
        _positionSpawnY = _positionSpawnY + _platformHeight;
        _positionTriggerSpawn = _target.position.y;
        _positionTriggerDestroy = _positionTriggerDestroy + _platformHeight;
        
    }

    private void FixedUpdate()
    {
        
        if (_platformsCount > 0)
            {
           var randomPlatform = _prefabPlatformVariats[Random.Range(0,_prefabPlatformVariats.Count)];
           var spawnedPlatform = Instantiate(randomPlatform, new Vector3(Random.Range(_platformEdges.x, _platformEdges.y), _positionSpawnY, 0), Quaternion.identity);
            _spawnedPlatforms.Enqueue(spawnedPlatform);
            _platformsCount--;
            _positionSpawnY = _positionSpawnY + _platformHeight;
            }

        else if (_target.position.y >_positionTriggerSpawn ) 
            { 
            _platformsCount++;
            _positionTriggerSpawn = _positionTriggerSpawn + _platformHeight;
            }
        else if (_target.position.y > _positionTriggerDestroy)
        {
            _positionTriggerDestroy += _platformHeight;
            var destroyPlatform = _spawnedPlatforms.Dequeue();
            Destroy(destroyPlatform.gameObject);
        }
    }
    


}


