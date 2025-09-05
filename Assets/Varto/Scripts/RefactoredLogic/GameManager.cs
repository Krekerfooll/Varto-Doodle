using UnityEngine;
using Varto.Examples.Platforms;
using Varto.Examples.Player;
using Varto.Examples.UI;
using Varto.Examples.Utils;

namespace Varto.Examples.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Varto_PlayerController _player;
        [SerializeField] private Varto_UiManager _uiManager;
        [SerializeField] private Varto_PlatformGenerator _platformGenerator;
        [Space]
        [SerializeField] private string _onCollectCoinEventName;
        [SerializeField] private string _onGameOverEventName;
        [SerializeField] private int _coinsAmountPerEvent;

        private void Awake()
        {
            var coinsCount = PlayerPrefs.GetInt("VARTO_DOODLE_COINS_COUNT", 0);

            _platformGenerator.Init();
            _platformGenerator.SetActive(true);
            _uiManager.Init(coinsCount);
            _player.Init();
        }

        private void OnEnable()
        {
            Varto_GlobalEventSender.OnEvent += OnAnyGlobalEvent;
            _uiManager.OnRestartRequested += OnRestartRequested;
        }
        private void OnDisable()
        {
            Varto_GlobalEventSender.OnEvent -= OnAnyGlobalEvent;
            _uiManager.OnRestartRequested -= OnRestartRequested;
        }

        private void OnAnyGlobalEvent(string eventName)
        {
            if (eventName == _onCollectCoinEventName)
            {
                _uiManager.AddCoins(_coinsAmountPerEvent);

                var coinsCount = _uiManager.CoinsCount;
                PlayerPrefs.SetInt("VARTO_DOODLE_COINS_COUNT", coinsCount);
                PlayerPrefs.Save();
            }
            else if (eventName == _onGameOverEventName)
            {
                _platformGenerator.SetActive(false);
                _uiManager.ShowGameOverScreen();
                Destroy(_player.gameObject);
            }
        }

        public void OnRestartRequested()
        {
            Varto_GameSessionManager.RestartGameSession();
        }
    }
}