using UnityEngine;
using UnityEngine.EventSystems;

namespace Ustich.Arthur.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Rigidbody2D _playerRB2D;

        [SerializeField] private float _groundCheckDistance;
        [SerializeField] private LayerMask _groundMask;

        private float _moveDirection;
        private bool _isGrounded;
        public bool IsGrounded { get { return _isGrounded; } }
        public float MoveDirection { get { return _moveDirection; } }


        private void Update()
        {
            Move();
            Jump();
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
            Debug.DrawLine(_playerRB2D.position, _playerRB2D.position + Vector2.down * _groundCheckDistance, Color.green);
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
                _playerRB2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}