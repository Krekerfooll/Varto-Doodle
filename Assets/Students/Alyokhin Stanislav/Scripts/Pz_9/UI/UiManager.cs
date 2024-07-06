using Alokhin.Stanislav.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Alokhin.Stanislav.Ui
{
    public class UiManager : MonoBehaviour
    {
        [Header("Global Settings")]
        [SerializeField] private string _onCollectCoinEventName;
        [SerializeField] private string _onGameOverEventName;
        [Space]
        [SerializeField] private int _coinsAmountPerEvent;

        [Space]
        [Header("Game Screen")]
        [SerializeField] private RectTransform _gameScreen;
        [SerializeField] private TextMeshProUGUI _gameScreenCoinsCounter;
        [SerializeField] private Button _pauseButton;

        [Space]
        [Header("Pause Screen")]
        [SerializeField] private RectTransform _pauseScreen;
        [SerializeField] private Button _resumeButton;
        [Space]

        private int _coinsCount;
        private void Awake()
        {
            _pauseButton.onClick.AddListener(OpenPauseScreen);

            GlobalEventSender.OnEvent += OnAnyGlobalEvent; 
        }
        private void OpenPauseScreen()
        {
            _pauseScreen.gameObject.SetActive(true);
        }
        private void ClosePauseScreen()
        {
            _pauseScreen.gameObject.SetActive(false);
        }
        private void OnAnyGlobalEvent(string eventName)
        {
            if (eventName == _onCollectCoinEventName)
            {
                _coinsCount += _coinsAmountPerEvent;

                _gameScreenCoinsCounter.text = _coinsCount.ToString();
                
            }
            else if(eventName == _onGameOverEventName)
            {
                
            }
        }
    }
}

