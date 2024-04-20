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
        [Header("Score UI")]
        [SerializeField] private NewPlayerController playerScript;
        [SerializeField] private TextMeshProUGUI scoreText;
        private string _gemCountString;
        
        [Space()][Header("TIMER")]
        [SerializeField] private float totalTime = 60f; 
        [SerializeField] private TextMeshProUGUI timerText; 
        private float _currentTime; 

        [Space()][Header("GameOverScreen")] 
        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private RawImage background;
        [SerializeField] private float duration = 2f;
        private readonly Color _originalColor = new Color(1f, 0.788f, 0.788f); // Колір FFC9C9 в форматі RGBA
        private Color _targetColor = new Color(1f, 0.231f, 0.231f);


        private void Start()
        {
            Time.timeScale = 1;
            timerText ??= GetComponent<TextMeshProUGUI>();
            _currentTime = totalTime;
        }


        private void Update()
        {
            ShowScores();
            Timer();
        }

        private void ShowScores()
        {
            scoreText.text = $"GEMS: {playerScript.gemCounter}";
        }

        private void Timer()
        {
            // Оновлення таймера
            _currentTime -= Time.deltaTime;
            // Форматування тексту для відображення у форматі хвилин:секунди
            int minutes = Mathf.FloorToInt(_currentTime / 60);
            int seconds = Mathf.FloorToInt(_currentTime % 60);
            timerText.text = $"{minutes:00}:{seconds:00}";
            
            if (_currentTime <= 0)
            {
                ShowGameOverScreen();
            }
        }

        private void ShowGameOverScreen()
        {
            gameOverScreen.SetActive(true); 
            scoreText.text = $"GEMS: {playerScript.gemCounter}";
            Time.timeScale = 0f;
            timerText.gameObject.SetActive(false);
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



