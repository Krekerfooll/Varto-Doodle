using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class ColorChangable : MonoBehaviour
    {
        [SerializeField] private bool _canChangeColor;
        public bool CanChangeColor { get { return _canChangeColor; } }
    }
}