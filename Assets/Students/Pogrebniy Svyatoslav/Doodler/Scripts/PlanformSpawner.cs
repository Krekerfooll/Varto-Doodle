 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
// using Varto.Examples.Platforms;
// using static UnityEngine.GraphicsBuffer;
// using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private float _plarformHeight;
    [SerializeField] private Vector2 _planformEdges;
    [SerializeField] private GameObject _prefabPlatform;
    [SerializeField] private Transform _target;
    [SerializeField] private int _platformsCount;
    [SerializeField] private float _positionSpawnY = -5;
    [SerializeField] private float _positionTriggerSpawn;
    [SerializeField] private float _positionTriggerDestroy;

    private Queue<GameObject> _spawnedPlatforms;

    private void Start()
    {
        _spawnedPlatforms = new Queue<GameObject>();
        var spawnedPlatform = Instantiate(_prefabPlatform, new Vector3(0, _positionSpawnY, 0), Quaternion.identity);
        _spawnedPlatforms.Enqueue(spawnedPlatform);
        _positionSpawnY = _positionSpawnY + _plarformHeight;
        _positionTriggerSpawn = _target.position.y;
        _positionTriggerDestroy = _positionTriggerDestroy + _plarformHeight;
        
    }

    private void FixedUpdate()
    {
        
        if (_platformsCount > 0)
            {
           var spawnedPlatform = Instantiate(_prefabPlatform, new Vector3(Random.Range(_planformEdges.x, _planformEdges.y), _positionSpawnY, 0), Quaternion.identity);
            _spawnedPlatforms.Enqueue(spawnedPlatform);
            _platformsCount--;
            _positionSpawnY = _positionSpawnY + _plarformHeight;
            }

        else if (_target.position.y >_positionTriggerSpawn ) 
            { 
            _platformsCount++;
            _positionTriggerSpawn = _positionTriggerSpawn + _plarformHeight;
            }
        else if (_target.position.y > _positionTriggerDestroy)
        {
            _positionTriggerDestroy += _plarformHeight;
            var destroyPlatform = _spawnedPlatforms.Dequeue();
            Destroy(destroyPlatform.gameObject);
        }
    }
    


}


