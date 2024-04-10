using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public abstract class BasePlatform : MonoBehaviour
    {
        [SerializeField] protected GameSettingsManager _gameSettingsManager;
        [SerializeField] private bool _changebleColor;
        public bool ChangebleColor { get { return _changebleColor; } }

        public virtual void Init(GameSettingsManager _manager)
        {
            _gameSettingsManager = _manager;
        }

        protected abstract void Move();
    }
}