using UnityEngine;

namespace Doodle.Core
{
    internal class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Collider2D _collider;

        [SerializeField] private float _jumpPower;
        [SerializeField] private float _movePower;

        private Vector3 _lookLeft;
        private Vector3 _lookRight;

        private bool _isJump;
        private float _moveDirection;

        private void Start()
        {
            _lookLeft = _rigidbody.transform.localScale;
            _lookRight = new Vector3(-_lookLeft.x, _lookLeft.y, _lookLeft.z);
        }
        private void Update()
        {
            GetJumpInput(KeyCode.W);
            GetHorizontalInput();
        }
        private void FixedUpdate()
        {
            if (!PlayerHelpers.IsPlayerGrounded(_rigidbody, _collider)) Move(_rigidbody, _movePower);
            else if(_isJump) Jump(_rigidbody, _jumpPower);
        }
        private void GetJumpInput(KeyCode key)
        {
            if (Input.GetKeyDown(key)) _isJump = true;
        }
        private void GetHorizontalInput()
        {
            _moveDirection = Input.GetAxis("Horizontal");
        }
        private void Move(Rigidbody2D rigidbody, float movePower)
        {
            rigidbody.velocity = new Vector2(_moveDirection * movePower, rigidbody.velocity.y);

            if(_moveDirection <= 0) _rigidbody.transform.localScale = _lookLeft;
            else _rigidbody.transform.localScale = _lookRight;
        }
        private void Jump(Rigidbody2D rigidbody, float jumpPower)
        {
            rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            _isJump = false;
        }
    }
}
