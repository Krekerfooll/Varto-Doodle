using Scripts;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private int _countPlatforms;
    [SerializeField] private float _maxHigthStep;
    [Space]
    [SerializeField] private List<PlatformBase> _listPrefabPlatform;

    [SerializeField] private Transform _player;
    [SerializeField] private Transform _cameraLowerTarget;

    PlatformBase[] _platforms;

    private int _indexPlatform = 0;
    private static float _lastRandomStepY = 0;
    private void Awake()
    {
        _platforms = new PlatformBase[_countPlatforms];
    }

    private void Start()
    {
        _platforms[_indexPlatform] = Instantiate(_listPrefabPlatform[0], _startPosition, Quaternion.identity, this.transform);
        _platforms[_indexPlatform].Init(_player.transform);
        _indexPlatform++;
        
        for(int i = 1; i < _countPlatforms; i++)
        {
            CreatePlatform();
        }
    }

    private void Update()
    {
        if(_cameraLowerTarget.transform.position.y > _platforms[_indexPlatform].transform.position.y)
        {
            CreatePlatform();
        }
    }

    private void CreatePlatform() 
    {
        if(_platforms[_indexPlatform] != null)
            Destroy(_platforms[_indexPlatform].gameObject);

        var randomPrefabPlatform = _listPrefabPlatform[Random.Range(0, _listPrefabPlatform.Count)];

        _lastRandomStepY += Random.Range(1f, _maxHigthStep);
        var randomStepX = Random.Range(-3f, 3f);
        var newPosition = new Vector2(randomStepX,_lastRandomStepY);

        _platforms[_indexPlatform] = Instantiate(randomPrefabPlatform, newPosition, Quaternion.identity, this.transform);
        _platforms[_indexPlatform].Init(_player.transform);
        
        _indexPlatform = (_indexPlatform == (_countPlatforms - 1)) ? 0 : ++_indexPlatform;  
    }




}
