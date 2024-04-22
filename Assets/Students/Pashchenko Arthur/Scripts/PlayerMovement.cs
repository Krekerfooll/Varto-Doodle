using UnityEngine;
namespace Artur.Pashchenko.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _jumpPower;
        [SerializeField] Rigidbody2D _playerRigidbody;
        [SerializeField] float _movementSpeed;
        [SerializeField] float _distanceForCast;
        [SerializeField] LayerMask _groundMask;
        [SerializeField] float _rotationSpeed;
        Quaternion _targetRotation;
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
                _playerRigidbody.velocity = new Vector2(InputController.Direction * _movementSpeed, _playerRigidbody.velocity.y);

                if (InputController.Direction < 0) 
                {
                    _targetRotation = Quaternion.Euler(this.transform.rotation.x, -180, this.transform.rotation.z);
                    transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
                }
                else if (InputController.Direction > 0)
                {
                    _targetRotation = Quaternion.Euler(this.transform.rotation.x, 0, this.transform.rotation.z);
                    transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
                }
              

               

            }  
        } 
    private void FixedUpdate()
        {
            _isGrounded = Physics2D.Raycast(_playerRigidbody.position, Vector2.down, _distanceForCast, _groundMask);
            Debug.DrawLine(_playerRigidbody.position, _playerRigidbody.position + Vector2.down * _distanceForCast, Color.red);


            if (_isGrounded)
            {
                if (transform.rotation.eulerAngles.y < 90f) transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                else if (transform.rotation.eulerAngles.y >= 90f) transform.rotation = Quaternion.Euler(0f, -180f, 0f);
            }
        }

    }
}