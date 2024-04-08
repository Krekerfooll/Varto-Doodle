using System.Collections;
using PVitaliy.Colors;
using PVitaliy.Platform;
using UnityEngine;

namespace PVitaliy
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private PlatformController platformController;
        [SerializeField] private Transform player;
        [SerializeField] private Transform losingPoint;
        [SerializeField] private GameUI gameUI;
        [SerializeField] private ColorTarget backgroundColor;
        private float _maxPlayerHeight;
        private void Awake()
        {
            platformController.Init();
            UpdateMaxPlayerHeight(0);
            StartCoroutine(nameof(BackgroundChangeCoroutine));
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
            return Mathf.RoundToInt(_maxPlayerHeight * platformController.GameScoreMultiplier);
        }

        private IEnumerator BackgroundChangeCoroutine()
        {
            while (true)
            {
                backgroundColor.ChangeTargetColor(Random.ColorHSV(0, 1, .8f, 1, .4f, .6f));
                yield return new WaitForSeconds(10);
            }
        }
    }
}