using UnityEngine;

namespace Artur.Pashchenko.DayAndNight
{
    public class ChangeOfDayAndNight : MonoBehaviour
    {
        [SerializeField] private Color _dayColor;
        [SerializeField] private Color _nightColor;
        private Color _targetColor;
        [SerializeField] private float _cycleTime;
        [SerializeField] private float _cycleDistance;

        private bool _isDay;
        private bool _isChangingColor;
        private float _lastCyclePosition;
        private float _colorChangeStartTime;
        private float _currentPosition;

        private void Start()
        {
            _lastCyclePosition = transform.position.y;
        }

        private void Update()
        {
            _currentPosition = transform.position.y;

            if (!_isChangingColor && _currentPosition - _lastCyclePosition >= _cycleDistance)
            {
                _isDay = !_isDay;
                _lastCyclePosition = transform.position.y;
                _targetColor = _isDay ? _nightColor : _dayColor;
                _colorChangeStartTime = Time.time;
                _isChangingColor = true;
                Debug.Log("Changing Color...");
            }

            if (_isChangingColor)
            {
                float elapsedTime = Time.time - _colorChangeStartTime;
                float t = Mathf.Clamp01(elapsedTime / _cycleTime);
                Color startColor = Camera.main.backgroundColor;
                Camera.main.backgroundColor = Color.Lerp(startColor, _targetColor, t);

                if (t >= 1.0f)
                {
                    _isChangingColor = false;
                    Debug.Log("Color Change Complete");
                }
            }
        }
    }
}
