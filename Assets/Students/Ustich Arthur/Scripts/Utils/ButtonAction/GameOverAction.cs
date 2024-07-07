using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class GameOverAction : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private List<ActionBase> _actions = new List<ActionBase>();
        public System.Action GameOver;
        private bool _gameOverIsInvoke = false;

        private void OnEnable()
        {
            GameSettingsManager.Instance.GameOverAction = this;
        }

        private void Update()
        {
            if (_target == null)
            {
                if (!_gameOverIsInvoke)
                {
                    GameOver?.Invoke();
                    _gameOverIsInvoke = true;
                }
                
                foreach (var action in _actions)
                    action.Execute();
            }
        }
    }
}