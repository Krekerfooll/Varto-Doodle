using UnityEngine;

namespace Alokhin.Stanislav
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb2;
        [Space]
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpPower;
        //[SerializeField] private float _maxSpeed;
        [Space]
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _groundCheckDistance;

        private Vector3 _lookLeft;
        private Vector3 _lookRight;
       //private bool _lookLeft;
       //private bool _lookRight;

        //private float _moveDiraction;
        private bool _isJump;
        private bool _isGrounded;

        private void Start()
        {
            _lookLeft = _rb2.transform.localScale;
            _lookRight = new Vector3(-_lookLeft.x, _lookLeft.y, _lookLeft.z);
        }
        private void Update()
        {
            CalculateJump();
            CalculateSpeed();
        }

        void FixedUpdate()
        {
            _isGrounded = Physics2D.Raycast(_rb2.position, Vector2.down, _groundCheckDistance, _groundMask);
            Debug.DrawLine(_rb2.position,_rb2.position + Vector2.down * _groundCheckDistance, Color.yellow);

            //var _moveDiraction = Input.GetAxis("Horizontal");

          //  if (_isGrounded)
          // {
          //     if (_isJump )
          //     {
          //         _rb2.AddForce(Vector2.up * _jumpPower,ForceMode2D.Impulse);
          //         _isJump = false;
          //     }
          // }
          // else
          // {
          //     _rb2.velocity = new Vector2(_speed * _moveDiraction, _rb2.velocity.y);
          // }
        }

        private void CalculateJump()
        {
            if(_isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                _rb2.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
                _isJump = true;
            }

        }
        private void CalculateSpeed()
        {
            var _moveDiraction = Input.GetAxis("Horizontal");
            _rb2.velocity = new Vector2(_speed * _moveDiraction, _rb2.velocity.y);

            if (_moveDiraction < 0f)
            {
                _rb2.transform.localScale = _lookLeft;
            }
            else if (_moveDiraction > 0f)
            {
                _rb2.transform.localScale = _lookRight;
            }

        }
    }


}
