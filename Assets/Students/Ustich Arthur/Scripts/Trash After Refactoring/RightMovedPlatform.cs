using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class RightMovedPlatform : BasePlatform
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Rigidbody2D _objectRigidbody;
        [SerializeField] private float _maxVelocityX;

        private void Update()
        {
            Move();
        }
        protected void Move()
        {
            float _positionX = transform.position.x;
            _objectRigidbody.AddForce(Vector2.right * _moveSpeed * Time.deltaTime, ForceMode2D.Force);

            if (_objectRigidbody.velocity.x > _maxVelocityX)
                _objectRigidbody.velocity = new Vector2(_maxVelocityX, _objectRigidbody.velocity.y);

            if (_positionX >= _gameSettingsManager.RightBounce)
                transform.position = new Vector2(_gameSettingsManager.LeftBounce, transform.position.y);
        }
    }
}