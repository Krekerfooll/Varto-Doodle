using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

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
            var data = PlayerPrefs.GetString("ASTRODOODLE_SAVE");
            if (data != "")
            {
                SaveDataList loadedData = JsonUtility.FromJson<SaveDataList>(data);
                _saveData = loadedData.SaveData;
                _maxScorePlace = _saveData.Count;

                _saveData = _saveData.OrderByDescending(saveData => saveData.Score).ToList();
                _maxScorePlace = Mathf.Min(_saveData.Count, _maxScorePlace);

                GenerateTable(_maxScorePlace, false);
            }
            else 
            {
                GenerateTable(1, true);
            }
        }

        public void GenerateTable(int placeCount, bool emptyTable)
        {
            for (int i = 0; i < placeCount; i++)
            {
                var _currentScorePosition = i + 1;
                Vector3 _position = transform.position;
                _scoreList.Add(Instantiate(_scorePrefab, _position, Quaternion.identity, this.transform));
                TextMeshProUGUI[] components = _scoreList[i].GetComponentsInChildren<TextMeshProUGUI>();

                foreach (var component in components)
                {
                    if (component.gameObject.name == "PlaceNumber" && !emptyTable)
                        component.text = _currentScorePosition.ToString();
                    else if (component.gameObject.name == "PlaceNumber" && emptyTable)
                        component.text = "";

                    if (component.gameObject.name == "Score" && _saveData.Count > 0 && !emptyTable)
                        component.text = $"{_saveData[i].Username}: {_saveData[i].Score}";
                    else if(component.gameObject.name == "Score" && emptyTable)
                        component.text = "You can be first!";
                }
            }
        }
    }
}