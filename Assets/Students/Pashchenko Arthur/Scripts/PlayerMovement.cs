using Doodle.core;
using UnityEngine;
namespace Doodle.core
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _jumpPower;
        [SerializeField] Rigidbody2D _playerRigidbody;
        [SerializeField] float _movementSpeed;
        [SerializeField] float _distanceForCast;
        [SerializeField] LayerMask _groundMask;
        private static bool _isGrounded;
        public static bool IsGrounded { get { return _isGrounded; } }

        private void Update()
        {
            Jump();
            Move();
        } 
        private void Jump()
{
            if (InputController.IsJumped && _isGrounded)
            {
               _playerRigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            }
        }
        private void Move()
        {
            if (!_isGrounded)
            {
                _playerRigidbody.velocity =new Vector2(InputController.Direction * _movementSpeed, _playerRigidbody.velocity.y);
            }
                
        } 
    private void FixedUpdate()
        {
            _isGrounded = Physics2D.Raycast(_playerRigidbody.position, Vector2.down, _distanceForCast, _groundMask);
            Debug.DrawLine(_playerRigidbody.position, _playerRigidbody.position + Vector2.down * _distanceForCast, Color.red);
        }

    }
}