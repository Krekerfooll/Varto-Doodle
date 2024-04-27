using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Ustich.Arthur.DoodleJump;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _textMeshProUGUIs = new List<TextMeshProUGUI>();
    [SerializeField] private ActionBase _changeScene;

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _scoreButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _exitButton;

    private void Awake()
    {
        FontResize();

        _startButton.onClick.AddListener(StartGame);
        _scoreButton.onClick.AddListener(OpenScore);
        _settingsButton.onClick.AddListener(OpenSettings);
        _creditsButton.onClick.AddListener(OpenScore);
        _exitButton.onClick.AddListener(ExitGame);
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


    private void OpenScore() => Debug.Log("At work!");
    private void OpenSettings() => Debug.Log("At work!");
    private void OpenCredits() => Debug.Log("At work!");

    private void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}