using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class GameSettingsManager : MonoBehaviour
    {
        [SerializeField] private float _leftBounce;
        [SerializeField] private float _rightBounce;
        [SerializeField] private SaveData _saveData;
        [SerializeField] private ChangeTextAction _changeTextAction;

        private static GameSettingsManager Instance;

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
        }

        public SaveData SaveData { get { return _saveData; } }

        public float LeftBounce { get { return _leftBounce; } }
        public float RightBounce { get { return _rightBounce; } }

        public void SetUsername(string name)
        {
            _saveData.Username = name;
        }

        public void SetScore(int score) 
        {
            _saveData.Score = score;
        }
    }
}