using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _player;
        [SerializeField] private float _playerSpeed;
        [SerializeField] private float _jumpPower;
        
        
        private Vector3 _lookLeft;
        private Vector3 _lookRight;
        private Vector3 _animJump;

        private float _moveDirection;
        private bool _isGrounded;
        
        private void Start()
        {
            _lookLeft = _player.transform.localScale;
            _lookRight = new Vector3(-_lookLeft.x, _lookLeft.y, _lookLeft.z);
        }
        private void Update()
        {
            CalculateJump();
            HorizontalMove();
        }
        private void HorizontalMove()
        {
            _moveDirection = Input.GetAxis("Horizontal");
            _player.velocity = new Vector2(_moveDirection * _playerSpeed, _player.velocity.y);
            if (_moveDirection < 0f)
                _player.transform.localScale = _lookLeft;
            else if (_moveDirection > 0f)
                _player.transform.localScale = _lookRight;
        }        
        private void CalculateJump()
        {
            if (_player.velocity.y >= _playerSpeed)
                _isGrounded = false;
                
            if (_isGrounded)
            {
                _player.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
                _isGrounded = false;
            }
        }
        private void OnTriggerStay2D(Collider2D other)
        {
            _isGrounded = true;
        }
        

    }
}
