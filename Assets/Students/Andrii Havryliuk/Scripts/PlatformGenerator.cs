using Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private int _countPlatforms;
    [SerializeField] private float _maxHigthStep;
    //[SerializeField] private int _generateDifficalty;
    [Space]
    [SerializeField] private List<GameObject> _listPrefabPlatform;

    //[SerializeField] private GameObject _player;

    GameObject[] _platforms;
    private int _indexPlatform = 0;
    private static float _lastRandomStepY = 0;
    private void Awake()
    {
        _platforms = new GameObject[_countPlatforms];
    }

    private void Start()
    {
        _platforms[_indexPlatform] = Instantiate(_listPrefabPlatform[0], _startPosition, Quaternion.identity, this.transform);
        _indexPlatform++;
        
        for(int i = 1; i < _countPlatforms; i++)
        {
            _platforms[_indexPlatform] = CreatePlatform();
        }
    }

    private void Update()
    {
        
    }

    private GameObject CreatePlatform() 
    {    
        var randomPrefabPlatform = _listPrefabPlatform[Random.Range(0, _listPrefabPlatform.Count)];
        _lastRandomStepY += Random.Range(2f, _maxHigthStep);
        var newPosition = new Vector2(0,_lastRandomStepY);
        var platform = Instantiate(randomPrefabPlatform, newPosition, Quaternion.identity, this.transform);
        Destroy(_platforms[_indexPlatform]);
        _indexPlatform = (_indexPlatform == (_countPlatforms - 1)) ? 0 : ++_indexPlatform;
        return platform;
    }




}
