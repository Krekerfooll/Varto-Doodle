using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class PlatformSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _targetPosition;
        [SerializeField] private GameObject _platformPrefab;

        private Vector3 _startPosition;
        private float _heithStep = 4;
        private float _currentHeith;
        [SerializeField] private float _leftBounce;
        [SerializeField] private float _rightBounce;
        [SerializeField] private List<GameObject> _platforms = new List<GameObject>();
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
                SpawnPlatform(2);
        }

        private void SpawnPlatform(int countToSpawn)
        {
            for (int i = 0; i < countToSpawn; i++)
            {
                _currentHeith += _heithStep;
                Vector3 _platformPosition = new Vector3(Random.Range(_leftBounce, _rightBounce), _currentHeith, _startPosition.z);
                _platforms.Add(Instantiate(_platformPrefab, _platformPosition, Quaternion.identity, this.transform));
                int _platformNumber = _platforms.Count;
                GameObject _tempObject = _platforms[_platformNumber - 1];
                _startPosition = _tempObject.transform.position;
                DestroyPlatform();
            }
        }

        private void DestroyPlatform()
        {
            if (_platforms.Count > 6)
            {
                Destroy(_platforms[0]);
                _platforms.RemoveAt(0);
            }
        }
    }
}