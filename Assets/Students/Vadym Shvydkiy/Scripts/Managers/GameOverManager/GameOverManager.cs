using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Button _reloadButton;
    private void Awake()
    {
        _reloadButton.onClick.AddListener(ReloadScene);
    }

    private void ReloadScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
}
