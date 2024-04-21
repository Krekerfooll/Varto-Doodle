using System;
using System.Collections;
using Students.Drobiniak_Volodymyr.Scripts.Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Students.Drobiniak_Volodymyr.Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("SCORE UI")]
        [SerializeField] private NewPlayerController playerScript;
        [SerializeField] private TextMeshProUGUI scoreText;
        
        
        [Space()][Header("TIMER")]
        [SerializeField] private float totalTime = 60f; 
        [SerializeField] private TextMeshProUGUI timerText; 
        

        [Space()][Header("GameOverUI")] 
        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private Image background;
        [SerializeField] private float changeDuration = 7f;
        private readonly Color _originalColor = new Color(1f, 0.788f, 0.788f); // Колір FFC9C9 в форматі RGBA
        private readonly Color _targetColor = Color.red;
        


        private void Start()
        {
            Time.timeScale = 1;
            timerText ??= GetComponent<TextMeshProUGUI>();
        }


        private void Update()
        {
            ShowScores();
            Timer();
            ShowGameOverScreen();
        }

        private void ShowScores()
        {
            scoreText.text = $"GEMS: {playerScript.gemCounter}";
        }

        private void Timer()
        {
            // Оновлення таймера
            totalTime -= Time.deltaTime;
            // Форматування тексту для відображення у форматі хвилин:секунди
            TimeSpan timeSpan = TimeSpan.FromSeconds(totalTime);
            timerText.text = $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
        }

        private void ShowGameOverScreen()
        {
            if (totalTime <= 0)
            {
                gameOverScreen.SetActive(true); 
                scoreText.text = $"GEMS: {playerScript.gemCounter}";
                // Time.timeScale = 0f;
                timerText.gameObject.SetActive(false);
                background.color = Color.Lerp(_originalColor, _targetColor, Mathf.PingPong(Time.time, changeDuration) / changeDuration );
                StartCoroutine(ChangeBackgroundColor());
                
            }
        }

        private IEnumerator ChangeBackgroundColor()
        {
            float elapsedTime = 0f; // Ініціалізуємо час, що пройшов

            while (elapsedTime < changeDuration) // Продовжуємо виконання досягнення 10 секунд
            {
                // Обчислюємо прогрес зміни кольору від 0 до 1 за 10 секунд
                float progress = elapsedTime / changeDuration;

                // Виконуємо плавну зміну кольору за допомогою Color.Lerp
                background.color = Color.Lerp(_originalColor, _targetColor, progress);

                // Очікуємо наступного кадру
                yield return null;

                // Оновлюємо час, що пройшов
                elapsedTime += Time.deltaTime;
            }
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;
            gameOverScreen.SetActive(false);
            timerText.gameObject.SetActive(true);
        }
    }
}



