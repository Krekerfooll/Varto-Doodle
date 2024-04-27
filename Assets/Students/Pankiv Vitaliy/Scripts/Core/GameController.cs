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
        [SerializeField] private GameUI gameUI;
        [SerializeField] private Camera mainCamera;
        private float _maxPlayerHeight;
        private Vector3 _playerStartPosition;
        private Vector3 _cameraStartPosition;
        private void Awake()
        {
            generator.Init();
            _playerStartPosition = player.transform.position;
            _cameraStartPosition = mainCamera.transform.position;
            RestartGame();
        }

        public void RestartGame() // Used at UI buttons
        {
            mainCamera.transform.position = _cameraStartPosition;
            player.transform.position = _playerStartPosition;
            player.ResetRigidBody();
            UpdateMaxPlayerHeight(0);
            generator.PreGeneratePlatforms();
            SetTimeScale(1);
        }

        private void Update()
        {
            var playerY = player.transform.position.y;
            if (playerY < losingPoint.position.y)
            {
                return;
            }
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
            gameUI.UpdateScore(ConvertHeightToScore());
        }

        public int ConvertHeightToScore()
        {
            return Mathf.RoundToInt(_maxPlayerHeight * generator.GameScoreMultiplier);
        }
    }
}