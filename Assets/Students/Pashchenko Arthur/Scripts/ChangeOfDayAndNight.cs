
using UnityEngine;
namespace Artur.Pashchenko.DayAndNight
{

    public class ChangeOfDayAndNight : MonoBehaviour
    {
        [SerializeField] Color _dayColor;
        [SerializeField] Color _nightColor;
        private Color _targetColor;
        [SerializeField] private float _cycleTime;
        [SerializeField] private float _cycleDistance;

        private bool _isDay;
        private float _lastCyclePosition;


        private void Start()
        {
            _lastCyclePosition = transform.position.y;
        }
        private void Update() 
        {
            if (Mathf.FloorToInt(_lastCyclePosition / _cycleDistance) < Mathf.FloorToInt(transform.position.y / _cycleDistance))
            {
                _lastCyclePosition = transform.position.y;
            }
        }


    }
}