using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class GameSettingsManager : MonoBehaviour
    {
        [SerializeField] private float _leftBounce;
        [SerializeField] private float _rightBounce;

        public float LeftBounce { get { return _leftBounce; } }
        public float RightBounce { get { return _rightBounce; } }
    }
}