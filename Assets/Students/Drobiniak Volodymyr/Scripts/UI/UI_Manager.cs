using System;
using Students.Drobiniak_Volodymyr.Scripts.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

namespace Students.Drobiniak_Volodymyr.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Score UI")]
        [SerializeField] private NewPlayerController playerScript;
        [SerializeField] private TextMeshProUGUI scoreText;
        [Space(2)]
        
        
        [Header("TIMER")]
        [SerializeField] private float totalTime = 60f; 
        [SerializeField] private TextMeshProUGUI _timerText; // Посилання на текстовий елемент для відображення таймера
        private float _currentTime; // Поточний час таймера

        private void Start()
        {
            _timerText ??= GetComponent<TextMeshProUGUI>();
            _currentTime = totalTime;
        }


        private void Update()
        {
            string gemCountString = playerScript.gemCounter.ToString();
            scoreText.text = $"GEMS: {gemCountString}";
            Timer();
            
        }

        private void Timer()
        {
            // Оновлення таймера
            _currentTime -= Time.deltaTime;
            // Форматування тексту для відображення у форматі хвилин:секунди
            int minutes = Mathf.FloorToInt(_currentTime / 60);
            int seconds = Mathf.FloorToInt(_currentTime % 60);
            _timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }
}


