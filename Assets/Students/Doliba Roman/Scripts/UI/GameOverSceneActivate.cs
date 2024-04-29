using RomanDoliba.Utils;
using UnityEngine;

namespace RomanDoliba.UI
{
    public class GameOverSceneActivate : MonoBehaviour
    {
        [SerializeField] private RectTransform _gameOverScreen;

        private void Awake()
        {
            OnTrigerEventSender.OnEvent += OnPlayerDeath;
        }

        public void OnPlayerDeath(string eventName)
        {
            if(eventName == "playerDead")
            {
                _gameOverScreen.gameObject.SetActive(true);
                OnTrigerEventSender.OnEvent -= OnPlayerDeath;
            }
        }
    }
}
