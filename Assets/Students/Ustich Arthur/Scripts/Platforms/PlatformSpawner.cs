using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class PlatformSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _targetPosition;
        [SerializeField] private List<GameObject> _platformPrefab = new List<GameObject>();

        private Vector3 _startPosition;
        private float _heithStep = 4;
        private float _currentHeith;

        [SerializeField] private List<GameObject> _platforms = new List<GameObject>();
        [SerializeField] private GameSettingsManager _gameSettingsManager;
        public List<GameObject> Platforms { get { return _platforms; } }

        [Space]
        [Header("TEST")]
        [SerializeField] private GameObject _basePlatform;
        [SerializeField] private List<GameObject> _notBasePlatforms = new List<GameObject>();
        private float _xOffset = 1.6f;

        private void Awake()
        {
            _startPosition = transform.position;
            _currentHeith = _startPosition.y;
            SpawnPlatform(0, 4);
        }

        private void Update()
        {
            if (_targetPosition.position.y > _platforms[1].transform.position.y + _heithStep)
                SpawnPlatform(Random.Range(1, 3), 1);
        }

        private void DestroyPlatform()
        {
            if (_platforms.Count > 25)
            {
                Destroy(_platforms[0]);
                _platforms.RemoveAt(0);
            }
        }

        private void InitPlatform(GameObject platformForInit)
        {
            if (platformForInit.TryGetComponent<MovedPlatform>(out MovedPlatform movedPlatform))
                movedPlatform.Init(_gameSettingsManager);
        }

        private void SpawnPlatform(int platformType, int countToSpawn)
        {
            switch (platformType)
            {
                case 0:
                    for (int i = 0; i < countToSpawn; i++)
                    {
                        _currentHeith += _heithStep;
                        Vector3 _platformPosition = new Vector3(Random.Range(_gameSettingsManager.LeftBounce, _gameSettingsManager.RightBounce), _currentHeith, transform.position.z);
                        var spawnerPlatform = Instantiate(_basePlatform, _platformPosition, Quaternion.identity, this.transform);
                        InitPlatform(spawnerPlatform);
                        _platforms.Add(spawnerPlatform);
                        DestroyPlatform();
                    }
                    break;
                case 1:
                    for (int i = 0; i < countToSpawn; i++)
                    {
                        _currentHeith += _heithStep;
                        float _positionX = Random.Range(_gameSettingsManager.LeftBounce, _gameSettingsManager.RightBounce);
                        int _countOfPlatforms = Random.Range(1, 3);
                        for (int j = 0; j < _countOfPlatforms; j++)
                        {
                            Vector3 _platformPosition = new Vector3(_positionX + (j*_xOffset), _currentHeith, transform.position.z);
                            var spawnerPlatform = Instantiate(_basePlatform, _platformPosition, Quaternion.identity, this.transform);
                            InitPlatform(spawnerPlatform);
                            _platforms.Add(spawnerPlatform);
                            DestroyPlatform();
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < countToSpawn; i++)
                    {
                        _currentHeith += _heithStep;
                        int _platformType = Random.Range(0, _notBasePlatforms.Count);
                        Vector3 _platformPosition = new Vector3(Random.Range(_gameSettingsManager.LeftBounce, _gameSettingsManager.RightBounce), _currentHeith, transform.position.z);
                        var spawnerPlatform = Instantiate(_notBasePlatforms[_platformType], _platformPosition, Quaternion.identity, this.transform);
                        InitPlatform(spawnerPlatform);
                        _platforms.Add(spawnerPlatform);
                        DestroyPlatform();
                    }
                    break;
            }
        }

        private void SpawnPlatform(int countToSpawn)
        {
            for (int i = 0; i < countToSpawn; i++)
            {
                _currentHeith += _heithStep;
                int _randPlatform = Random.Range(0, _platformPrefab.Count);
                Vector3 _platformPosition = new Vector3(Random.Range(_gameSettingsManager.LeftBounce, _gameSettingsManager.RightBounce), _currentHeith, transform.position.z);
                var spawnerPlatform = Instantiate(_platformPrefab[_randPlatform], _platformPosition, Quaternion.identity, this.transform);
                InitPlatform(spawnerPlatform);
                _platforms.Add(spawnerPlatform);
                DestroyPlatform();
            }
        }
    }
}