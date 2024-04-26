using System;
using RomanDoliba.Utils;
using TMPro;
using UnityEngine;

namespace RomanDoliba.UI
{
    public class CoinsCounter : MonoBehaviour
    {
        [SerializeField] private string _coinCollectEventName;
        [SerializeField] private string _diamondCollectEventName;
        [SerializeField] private TextMeshProUGUI _coinsCounter;
        private int _coinsCount = 0;

        private void Awake()
        {
            _coinsCounter.text = _coinsCount.ToString();
            OnTrigerEventSender.OnEvent += OnTrigerEvent;
        }
        private void OnTrigerEvent(string eventName)
        {
            if(eventName == _coinCollectEventName)
            {
                _coinsCount += 1;
                _coinsCounter.text = _coinsCount.ToString();
            }
            else if(eventName == _diamondCollectEventName)
            {
                _coinsCount += 10;
                _coinsCounter.text  = _coinsCount.ToString();
            }
        }
    }
}
