using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _prefabsForSpawn = new List<GameObject>();
        [SerializeField] private GameSettingsManager _gameSettingsManager;
        [SerializeField] private float _height;
        [SerializeField] private Transform _target;
        [Space]
        [Header("DEBUG")]
        [SerializeField] private List<GameObject> _spawnedObjects = new List<GameObject>();
        [Space]
        private float _rightBounce;
        private float _leftBounce;
        private int _heightStep = 1;
        private float _startPosY;

        public List<GameObject> SpawnedObjects { get {  return _spawnedObjects; } }

        private void Awake()
        {
            GetBounce();
            _startPosY = _target.position.y;
        }

        private void Update()
        {
            Spawn();
            Destroyer();
        }

        private void Spawn()
        {
            if (_spawnedObjects.Count < 10)
            {
                int _prefabNumber = Random.Range(0, _prefabsForSpawn.Count);
                float _posXtoSpawn = Random.Range(_leftBounce, _rightBounce);
                float _posYtoSpawn = _startPosY + (_height * _heightStep);
                Vector3 _posToSpawn = new Vector3(_posXtoSpawn, _posYtoSpawn, 0);
                _spawnedObjects.Add(Instantiate(_prefabsForSpawn[_prefabNumber], _posToSpawn, Quaternion.identity, this.transform));
                if (_spawnedObjects[_spawnedObjects.Count - 1].TryGetComponent<MovedPlatform>(out MovedPlatform movedPlatform))
                    movedPlatform.Init(_gameSettingsManager);
                _heightStep += 1;
            }
        }

        private void GetBounce()
        {
            _rightBounce = _gameSettingsManager.RightBounce;
            _leftBounce = _gameSettingsManager.LeftBounce;
        }

        private void Destroyer()
        {
            int _counter = 0;
            foreach (var objects in _spawnedObjects)
            {
                if (objects == null)
                {
                    _spawnedObjects.RemoveAt(_counter);
                    break;
                }
                    
                if (objects != null)
                    _counter++;
            }
        }
    }
}