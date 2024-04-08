using UnityEngine;

namespace Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _player;
        [Space]
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpPower;
        [Space]
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _groundCheckDistance;

        private Vector3 _lookLeft;
        private Vector3 _lookRight;

        private float _moveDirection;
        private bool _isJump;
        private bool _isGrounded;




        void Start()
        {
            _lookLeft = _player.transform.localScale;
            _lookRight = new Vector3(-_lookLeft.x, _lookLeft.y, _lookLeft.z);

        }

        void Update()
        {
            PowerJump();
            PowerSpeed();
        }

        private void FixedUpdate()
        {
            _isGrounded = Physics2D.Raycast(_player.position, Vector2.down, _groundCheckDistance, _groundMask);
            Debug.DrawLine(_player.position, _player.position + Vector2.down * _groundCheckDistance, Color.magenta);

            if (_isGrounded)
            {
                if (_isJump)
                {
                    _player.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
                    _isJump = false;
                }
            }
            else
            {
                _player.velocity = new Vector2(_speed * _moveDirection, _player.velocity.y);
            }
        }

        private void PowerJump()
        {
            _isJump = true;
        }

        private void PowerSpeed()
        {
            _moveDirection = Input.GetAxis("Horizontal");

            if (_moveDirection < 0f)
                _player.transform.localScale = _lookLeft;
            else if (_moveDirection > 0f)
                _player.transform.localScale = _lookRight;
        }


    }

}
