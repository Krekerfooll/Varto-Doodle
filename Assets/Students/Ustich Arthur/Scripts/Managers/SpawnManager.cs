using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GetRandomPlatformPattern _getRandomPlatformPattern;
        [SerializeField] private GameSettingsManager _gameSettingsManager;
        [SerializeField] private float _height;
        [SerializeField] private Transform _target;
        
        private List<GameObject> _spawnedObjects = new List<GameObject>();
        private float _rightBounce;
        private float _leftBounce;
        private int _heightStep = 1;
        private float _startPosY;
        private int _maxPlatformCountonScene = 15;

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
            if (_spawnedObjects.Count < _maxPlatformCountonScene)
            {
                float _posXtoSpawn = Random.Range(_leftBounce, _rightBounce);
                float _posYtoSpawn = _startPosY + (_height * _heightStep);
                
                var Position = new Vector2(_posXtoSpawn, _posYtoSpawn);
                _spawnedObjects.Add(_getRandomPlatformPattern.SpawnRandomPlatform(_target.gameObject, Position, this.transform));

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