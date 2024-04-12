using System.Collections.Generic;
using UnityEngine;

namespace Doodle.Core
{
    internal class BackgroundManager : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Collider2D _collider;

        [SerializeField] private List<Color> _backgroundColorList;

        private static int _currentColorIndex = 0;
        private static bool isGrounded = false;

        private void FixedUpdate()
        {
            ChangeBackgroundColor(_backgroundColorList, _rigidbody, _collider);
        }
        private void ChangeBackgroundColor(List<Color> backgroundColorList, Rigidbody2D rigidbody, Collider2D collider)
        {
            bool prevIsGrounded = isGrounded;
            isGrounded = PlayerHelpers.IsPlayerGrounded(rigidbody, collider);
            if (prevIsGrounded == false && isGrounded == true)
            {
                _currentColorIndex++;
                if (_currentColorIndex >= backgroundColorList.Count) _currentColorIndex = 0;

                Camera.main.backgroundColor = backgroundColorList[_currentColorIndex];
            }
        }
    }
}
