using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OIMOD.Core.GameMech
{
    public class OI_GameOverManager : MonoBehaviour
    {
        [SerializeField] Transform _player;
        [SerializeField] Transform _deathZone;
        [SerializeField] Transform _gameOverText;
        [SerializeField] TextMeshProUGUI _scoreText;
        [SerializeField] GameObject scoreSystem;

        private bool _isGameOver;
        private void Start()
        {
            _isGameOver = false;
            _gameOverText.gameObject.SetActive(false);
        }
        void Update()
        {
            CheckGameOver();
            if (_isGameOver)
                GameOver();
        }
        private void CheckGameOver()
        {
            if (_player.position.y < _deathZone.position.y)
                _isGameOver = true;
            else
                _isGameOver = false;
        }
        private void GameOver()
        {
            var score = scoreSystem.GetComponent<OI_ScoreSystem>()._score;
            _gameOverText.gameObject.SetActive(true);

            _scoreText.alignment = TextAlignmentOptions.Midline;

            if (Input.GetKeyDown(KeyCode.R) || (Input.GetKeyDown(KeyCode.KeypadEnter)))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

