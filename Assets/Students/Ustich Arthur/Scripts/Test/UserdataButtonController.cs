using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ustich.Arthur.DoodleJump
{
    //TESTING SCRIPT
    public class UserdataButtonController : MonoBehaviour
    {
        [SerializeField] private GameSettingsManager _gameSettingsManager;

        [SerializeField] private Button _usernameButton;
        [SerializeField] private TMP_InputField _usernameInput;
        [SerializeField] private Button _scoreButton;
        [SerializeField] private TMP_InputField _scoreInput;
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _loadButton;
        [SerializeField] private List<SaveData> _saveData = new List<SaveData>();

        private void Awake()
        {
            _usernameButton.onClick.AddListener(SetUsername);
            _scoreButton.onClick.AddListener(SetScore);
            _saveButton.onClick.AddListener(SaveGame);
            _loadButton.onClick.AddListener(LoadGame);
        }

        private void SetUsername()
        {
            _gameSettingsManager.SetUsername(_usernameInput.text);
        }

        private void SetScore()
        {
            if (int.TryParse(_scoreInput.text, out int Score))
                _gameSettingsManager.SetScore(Score);
        }

        private void SaveGame()
        {
            _saveData.Add(_gameSettingsManager.SaveData);
            SaveDataList dataForSave = new SaveDataList(_saveData);
            var data = JsonUtility.ToJson(dataForSave);
            PlayerPrefs.SetString("ASTRODOODLE_SAVE", data);
        }

        private void LoadGame()
        {
            var data = PlayerPrefs.GetString("ASTRODOODLE_SAVE");
            SaveDataList loadedData = JsonUtility.FromJson<SaveDataList>(data);
            _saveData = loadedData.SaveData;
        }
    }



    [System.Serializable]
    public struct SaveData
    {
        public string Username;
        public int Score;
    }

    [System.Serializable]
    public struct SaveDataList
    {
        public List<SaveData> SaveData;

        public SaveDataList (List<SaveData> saveData)
        {
            SaveData = saveData;
        }
    }
}