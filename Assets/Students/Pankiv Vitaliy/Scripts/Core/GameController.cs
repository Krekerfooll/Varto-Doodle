using PVitaliy.Platform;
using UnityEngine;

namespace PVitaliy
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private PlatformGenerator generator;
        [SerializeField] private Transform player;
        [SerializeField] private Transform losingPoint;
        [SerializeField] private GameUI gameUI;
        private float _maxPlayerHeight;
        private void Awake()
        {
            generator.Init();
            UpdateMaxPlayerHeight(0);
        }

        private void Update()
        {
            var playerY = player.position.y;
            if (playerY < losingPoint.position.y)
            {
                return;
            }
            if (_maxPlayerHeight < playerY)
                UpdateMaxPlayerHeight(playerY);
        }

        private void UpdateMaxPlayerHeight(float value)
        {
            losingPoint.position += Vector3.up * (value - _maxPlayerHeight);
            _maxPlayerHeight = value;
            gameUI.UpdateScore(ConvertHeightToScore());
        }

        private int ConvertHeightToScore()
        {
            return Mathf.RoundToInt(_maxPlayerHeight * generator.GameScoreMultiplier);
        }
    }
}