using UnityEngine;

namespace PVitaliy.Components
{
    public class SlidingHorizontally : MonoBehaviour
    {
        [SerializeField] private float minSpeed = 1f;
        [SerializeField] private float maxSpeed = 2f;
        [SerializeField] private Rigidbody2D rigidBody;
        private Transform _leftPoint;
        private Transform _rightPoint;
        private int _currentDirectionX;
        private float _speed;
        private bool _pointsSet;

        public void SetPoints(Transform leftPoint, Transform rightPoint)
        {
            _leftPoint = leftPoint;
            _rightPoint = rightPoint;
            _pointsSet = true;
        }

        private void Awake()
        {
            _speed = Random.Range(minSpeed, maxSpeed);
            _currentDirectionX = Random.value > .5 ? -1 : 1;
        }
        
        protected void Update()
        {
            if (!_pointsSet) return;
            rigidBody.velocity = new Vector2(_currentDirectionX * _speed, 0); //TODO: зробити анімацією (мабуть)
            ChangeDirectionIfCan();
        }

        private void ChangeDirectionIfCan()
        {
            if (_currentDirectionX == -1 && transform.position.x <= _leftPoint.position.x) _currentDirectionX = 1; 
            else if (transform.position.x >= _rightPoint.position.x) _currentDirectionX = -1;
        }
    }
}