using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Ustich.Arthur.DoodleJump
{
    public class MovedPlatform : BasePlatform
    {
        [Space]
        [Header("Moved Platform variables:")]
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Rigidbody2D _objectRigidbody;
        [SerializeField] private bool _moveRight;

        private void Start()
        {
            _bounceLeft = _gameSettingsManager.LeftBounce;
            _bounceRight = _gameSettingsManager.RightBounce;
            ChangeMoveDirectiom();
        }
        private void Update()
        {
            Move();
            TeleportOnBounce();
        }
        protected void Move() => _objectRigidbody.velocity = new Vector2(_moveSpeed, transform.position.y);

        private void TeleportOnBounce()
        {
            _positionX = transform.position.x;
            _positionY = transform.position.y;
            if(_positionX >= _bounceRight)
                transform.position = new Vector2(_bounceLeft, _positionY);
            if (_positionX <= _bounceLeft)
                transform.position = new Vector2(_bounceRight, _positionY);
        }

        private void ChangeMoveDirectiom()
        {
            if (!_moveRight)
                _moveSpeed *= -1;
        }
    }
}