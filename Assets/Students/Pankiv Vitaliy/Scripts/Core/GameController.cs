using PVitaliy.Core;
using PVitaliy.Platform;
using PVitaliy.Player;
using PVitaliy.UI;
using UnityEngine;

namespace PVitaliy
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private PlatformGenerator generator;
        [SerializeField] private PlayerMovement player;
        [SerializeField] private Transform losingPoint;
        [SerializeField] private UIManager uiManager;
        [SerializeField] private Camera mainCamera;
        private float _maxPlayerHeight;
        private Vector3 _playerStartPosition;
        private Vector3 _cameraStartPosition;

        private int _localRecord; 
        private void Awake()
        {
            _localRecord = PlayerPrefs.GetInt(MaxRecordView.RecordKey);
            generator.Init();
            _playerStartPosition = player.transform.position;
            _cameraStartPosition = mainCamera.transform.position;
            GenerateNewLevel();
        }

        public void GenerateNewLevel()
        {
            mainCamera.transform.position = _cameraStartPosition;
            player.transform.position = _playerStartPosition;
            player.ResetRigidBody();
            UpdateMaxPlayerHeight(0);
            generator.PreGeneratePlatforms();
            SetTimeScale(1);
        }

        public void SetPlayerActive(bool active)
        {
            player.gameObject.SetActive(active);
        }

        private void Update()
        {
            var playerY = player.transform.position.y;
            if (_maxPlayerHeight < playerY)
                UpdateMaxPlayerHeight(playerY);
        }

        public void SetTimeScale(float value)
        {
            Time.timeScale = value;
        }

        private void UpdateMaxPlayerHeight(float value)
        {
            losingPoint.position += Vector3.up * (value - _maxPlayerHeight);
            _maxPlayerHeight = value;
            uiManager.GameScore = ConvertHeightToScore();
        }

        public int ConvertHeightToScore()
        {
            return Mathf.RoundToInt(_maxPlayerHeight * generator.GameScoreMultiplier);
        }

        public void OnLosingPointTriggered() // used in LosingTrigger
        {
            uiManager.OnGameOver();
            var score = ConvertHeightToScore();
            if (_localRecord < score)
            {
                GlobalEvents.CallEvent(EventNames.NewRecordSet, score);
            }
        }
    }
}