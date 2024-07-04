using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class GenarateScoreTable : MonoBehaviour
    {
        [SerializeField] private GameObject _scorePrefab;
        [SerializeField] private List<GameObject> _scoreList = new List<GameObject>();
        [SerializeField] private List<SaveData> _saveData = new List<SaveData>();
        private int _maxScorePlace = 10;

        private void Awake()
        {
            if (PlayerPrefs.GetString("ASTRODOODLE_SAVE") != null)
            {
                var data = PlayerPrefs.GetString("ASTRODOODLE_SAVE");
                SaveDataList loadedData = JsonUtility.FromJson<SaveDataList>(data);
                _saveData = loadedData.SaveData;
                _maxScorePlace = _saveData.Count;
            }


            for (int i = 0; i < _maxScorePlace; i++)
            {
                var _currentScorePosition = i + 1;
                Vector3 _position = transform.position;             
                _scoreList.Add(Instantiate(_scorePrefab, _position, Quaternion.identity, this.transform));
                TextMeshProUGUI[] components = _scoreList[i].GetComponentsInChildren<TextMeshProUGUI>();
               
                foreach (var component in components)
                {
                    if (component.gameObject.name == "PlaceNumber")
                        component.text = _currentScorePosition.ToString();
                    if (component.gameObject.name == "Score" && _saveData.Count > 0)
                        component.text = $"{_saveData[i].Username}: {_saveData[i].Score}";
                }
            }
        }
    }
}