using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class SpawnBackGround : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private float _spawnStep;
        [SerializeField] private GameObject _backGroundPrefab;
        private Vector3 _spawnPosition = new Vector3(0, 0, 0);
        [SerializeField] private List<GameObject> _backGrounds = new List<GameObject>();

        private void Awake()
        {
            _backGrounds.Add(Instantiate(_backGroundPrefab, _spawnPosition, Quaternion.identity, this.transform));
            Debug.Log($"{_backGrounds[_backGrounds.Count - 1].transform.position.y}");
        }

        private void Update()
        {
            Spawn();
            DestroyBackGrond();
        }

        private void Spawn()
        {
            if (_targetTransform.position.y + 5 >= _spawnPosition.y) //_backGrounds[_backGrounds.Count - 1].transform.position.y)
            {
                _spawnPosition = new Vector3(_spawnPosition.x, _spawnPosition.y + _spawnStep, _spawnPosition.z);
                _backGrounds.Add(Instantiate(_backGroundPrefab, _spawnPosition, Quaternion.identity, this.transform));
            }
        }

        private void DestroyBackGrond()
        {
            if (_backGrounds.Count >= 4)
            {
                Destroy(_backGrounds[0]);
                _backGrounds.RemoveAt(0);
            }
        }
    }
}
