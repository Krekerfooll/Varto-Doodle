using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Ustich.Arthur.DoodleJump;

public class UI_Controller : MonoBehaviour
{
    [Header("TextForFormating")]
    [SerializeField] private List<TextMeshProUGUI> _textMeshProUGUIs = new List<TextMeshProUGUI>();

    [Space]
    [Header("Button actions")]
    [SerializeField] private ActionBase _changeScene;
    [SerializeField] private ActionBase _openScore;
    [SerializeField] private ActionBase _backToMenu;

    [Space]
    [Header("Buttons")]
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _scoreButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _exitButton;

    [Space]
    [Header("Score table buttons")]
    [SerializeField] private Button _BackToMenuButton;
    [SerializeField] private Button _backScoreButton;

    private void Awake()
    {
        FontResize();
        _backToMenu.Execute();

        _startButton.onClick.AddListener(StartGame);
        _scoreButton.onClick.AddListener(OpenScore);
        _settingsButton.onClick.AddListener(OpenSettings);
        _creditsButton.onClick.AddListener(OpenCredits);
        _exitButton.onClick.AddListener(ExitGame);
        _BackToMenuButton.onClick.AddListener(BackToMenu);
        _backScoreButton.onClick.AddListener(BackToMenu);
    }
    private void FontResize()
    {
        float maxFontSize = _textMeshProUGUIs[0].fontSize;
        foreach (TextMeshProUGUI tempText in _textMeshProUGUIs)
        {
            if(tempText.fontSize > maxFontSize)
                maxFontSize = tempText.fontSize;
        }

        for (int i = 0; i < _textMeshProUGUIs.Count; i++)
        {
            _textMeshProUGUIs[i].enableAutoSizing = false;
            _textMeshProUGUIs[i].fontSize = maxFontSize;
        }
    }

    private void StartGame() => _changeScene.Execute();


    private void OpenScore() => _openScore.Execute();
    private void OpenSettings() => Debug.Log("At work!");
    private void OpenCredits() => Debug.Log("At work!");
    private void BackToMenu() => _backToMenu.Execute();

    private void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}