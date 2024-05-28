using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scroll : MonoBehaviour
{
    [SerializeField] private string _text01;
    [SerializeField] private string _text02;
    [SerializeField] private TextMeshProUGUI _gameScreenTap01;
    [SerializeField] private TextMeshProUGUI _gameScreenTap02;
    [SerializeField] private Button _tapButton01;
    [SerializeField] private Button _tapButton02;
    [SerializeField] private Button _reloadButton;

    private void Awake()
    { 
    _tapButton01.onClick.AddListener(Tap01);
    _tapButton02.onClick.AddListener(Tap02);
    _reloadButton.onClick.AddListener(ReloadScene);
    }

    private void Tap01()
    {
        _gameScreenTap01.text += _text01;
    }
    private void Tap02()
    {
        _gameScreenTap02.text += _text02;
    }
    private void ReloadScene()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
