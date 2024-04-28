using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class GenarateScoreTable : MonoBehaviour
    {
        [SerializeField] private GameObject _scorePrefab;
        [SerializeField] private List<GameObject> _scoreList = new List<GameObject>();
        private int _maxScorePlace = 30;

        private void Awake()
        {
            for (int i = 0; i < _maxScorePlace; i++)
            {
                var _currentScorePosition = i + 1;
                Vector3 _position = transform.position;             
                _scoreList.Add(Instantiate(_scorePrefab, _position, Quaternion.identity, this.transform));
                _scoreList[i].GetComponentInChildren<TextMeshProUGUI>().text = _currentScorePosition.ToString();
            }
        }
    }
}