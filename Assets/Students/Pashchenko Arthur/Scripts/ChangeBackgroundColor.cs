using Artur.Pashchenko.Player;
using System.Net.Http.Headers;
using UnityEngine;
namespace Artur.Pashchenko.Background
{
    public class ChangeBackgroundColor : MonoBehaviour
    {
        [SerializeField] private float _colorChangeSpeed;
        [SerializeField] public Color[] AvailableColors;
        private int _randomColor;
        private Color _targetColor;
        private bool _isChangingColor = false;

        private void Update()
        {

            if (InputController.IsJumped && PlayerMovement.IsGrounded)
            {
                _randomColor = Random.Range(0, AvailableColors.Length);
                _targetColor = AvailableColors[_randomColor];
                _isChangingColor = true;
            }
            if (_isChangingColor)
            {    
                Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, _targetColor, Time.deltaTime * _colorChangeSpeed);
                if (Vector4.Distance(Camera.main.backgroundColor, _targetColor) < 0.05f)
                {
                    _isChangingColor = false;
                }
            }

        }
    }
}