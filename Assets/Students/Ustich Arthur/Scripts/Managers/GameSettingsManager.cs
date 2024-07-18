using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class GameSettingsManager : MonoBehaviour
    {
        [SerializeField] private float _leftBounce;
        [SerializeField] private float _rightBounce;
        [SerializeField] private SaveData _currentGameData;
        [SerializeField] private ChangeTextAction _changeTextAction;
        [SerializeField] private GameOverAction _gameOverAction;

        public ChangeTextAction ChangeTextAction
        {
            get 
            { 
                return _changeTextAction; 
            }

            set 
            {
                if(_changeTextAction == null)
                {
                    _changeTextAction = value;
                    _changeTextAction.ChangeScore += SetScore;
                }
            }
        }

        public GameOverAction GameOverAction
        {
            get
            {
                return _gameOverAction;
            }

            set
            {
                if (_gameOverAction == null)
                {
                    _gameOverAction = value;
                    _gameOverAction.GameOver += SaveGame;
                }
            }
        }

        public static GameSettingsManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                transform.SetParent(null);
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);


            if(_changeTextAction != null)
                _changeTextAction.ChangeScore += SetScore;

            if(_gameOverAction != null)
                _changeTextAction.ChangeScore += SetScore;
        }

        public SaveData SaveData { get { return _currentGameData; } }

        public float LeftBounce { get { return _leftBounce; } }
        public float RightBounce { get { return _rightBounce; } }

        public void SetUsername(string name)
        {
            _currentGameData.Username = name;
        }

        public void SetScore(int score) 
        {
            _currentGameData.Score = score;
        }

        private void SaveGame()
        {
            List<SaveData> LoadedData = new List<SaveData>();
            LoadedData = LoadGame().SaveData;

            if (LoadedData.Count > 9)
            {
                int MinScore = LoadedData[0].Score;
                int MinIndex = 0;

                for (int i = 0; i < LoadedData.Count; i++)
                {
                    if (LoadedData[i].Score < MinScore)
                    {
                        MinScore = LoadedData[i].Score;
                        MinIndex = i;
                    }
                }

                if (MinScore < _currentGameData.Score)
                {
                    LoadedData.RemoveAt(MinIndex);
                    LoadedData.Add(_currentGameData);
                }
            }
            else
            {
                LoadedData.Add(_currentGameData);
            }

            SaveGame(LoadedData);
        }

        private SaveDataList LoadGame()
        {
            var data = PlayerPrefs.GetString("ASTRODOODLE_SAVE");
            if (data != "")
            {
                SaveDataList loadedData = JsonUtility.FromJson<SaveDataList>(data);
                return loadedData;
            }
            else
            {
                List<SaveData> saveData = new List<SaveData>();
                SaveGame(saveData);
                data = PlayerPrefs.GetString("ASTRODOODLE_SAVE");
                SaveDataList loadedData = JsonUtility.FromJson<SaveDataList>(data);
                return loadedData;
            }
        }

        private void SaveGame(List<SaveData> saveData)
        {
            if (saveData != null)
            {
                SaveDataList dataForSave = new SaveDataList(saveData);
                var data = JsonUtility.ToJson(dataForSave);
                PlayerPrefs.SetString("ASTRODOODLE_SAVE", data);
            }
        }
    }
}