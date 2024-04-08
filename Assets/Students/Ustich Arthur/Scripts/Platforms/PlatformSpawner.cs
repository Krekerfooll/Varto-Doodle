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

        private void Awake()
        {
            _startPosition = transform.position;
            _currentHeith = _startPosition.y;
            SpawnPlatform(4);
        }

        private void Update()
        {
            if (_targetPosition.position.y > _platforms[1].transform.position.y + _heithStep)
                SpawnPlatform(1);
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

        private void DestroyPlatform()
        {
            if (_platforms.Count > 10)
            {
                Destroy(_platforms[0]);
                _platforms.RemoveAt(0);
            }
        }

        private void InitPlatform(GameObject platformForInit)
        {
            if (platformForInit.TryGetComponent<RightMovedPlatform>(out RightMovedPlatform moveRightPlatform))
                moveRightPlatform.Init(_gameSettingsManager);
            if (platformForInit.TryGetComponent<LeftMovedPlatform>(out LeftMovedPlatform moveLeftPlatform))
                moveLeftPlatform.Init(_gameSettingsManager);
        }
    }
}