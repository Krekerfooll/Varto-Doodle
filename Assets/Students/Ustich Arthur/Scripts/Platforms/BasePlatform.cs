using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class BasePlatform : MonoBehaviour
    {
        [SerializeField] protected GameSettingsManager _gameSettingsManager;
        protected float _bounceLeft;
        protected float _bounceRight;
        protected float _positionX;
        protected float _positionY;

        public virtual void Init(GameSettingsManager _manager)
        {
            _gameSettingsManager = _manager;
        }
    }
}