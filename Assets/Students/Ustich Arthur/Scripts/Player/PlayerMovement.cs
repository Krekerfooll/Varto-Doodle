using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Ustich.Arthur.DoodleJump
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private GameSettingsManager _gameSettingsManager;

        [SerializeField] private float _jumpForce;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Rigidbody2D _playerRB2D;

        [SerializeField] private float _groundCheckDistance;
        [SerializeField] private LayerMask _groundMask;

        [SerializeField] private ActionBase _actionIfJump;

        private float _moveDirection;
        private bool _isGrounded;
        public bool IsJumping { get; private set; }
        public bool IsGrounded { get { return _isGrounded; } }
        public float MoveDirection { get { return _moveDirection; } }

        private void Awake()
        {
            _gameSettingsManager = GameSettingsManager.Instance;
        }

        private void Update()
        {
            Move();
            Jump();
            TeleportOnBounde();
        }
        private void Move()
        {
            _moveDirection = Input.GetAxis("Horizontal");
            if (!_isGrounded)
                _playerRB2D.velocity = new Vector2(_moveDirection * _moveSpeed, _playerRB2D.velocity.y);
        }

        private void Jump()
        {
            _isGrounded = Physics2D.Raycast(_playerRB2D.position, Vector2.down, _groundCheckDistance, _groundMask);
            IsJumping = !_isGrounded;
            Debug.DrawLine(_playerRB2D.position, _playerRB2D.position + Vector2.down * _groundCheckDistance, Color.green);
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                _playerRB2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _actionIfJump.Execute();
            }
                
                
        }

        private void TeleportOnBounde()
        {
            if (_gameSettingsManager != null)
            {
                if (transform.position.x < _gameSettingsManager.LeftBounce)
                    transform.position = new Vector2(_gameSettingsManager.RightBounce, transform.position.y);
                if (transform.position.x > _gameSettingsManager.RightBounce)
                    transform.position = new Vector2(_gameSettingsManager.LeftBounce, transform.position.y);
            }
        }
    }
}