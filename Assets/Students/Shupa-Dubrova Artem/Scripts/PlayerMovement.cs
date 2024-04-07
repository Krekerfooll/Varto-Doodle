using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _player;
        [SerializeField] private GameObject _spriteIdle;
        [SerializeField] private GameObject _spriteJump;
        [SerializeField] private float _playerSpeed;
        [SerializeField] private float _jumpPower;
        
        
        private Vector3 _lookLeft;
        private Vector3 _lookRight;

        private float _moveDirection;
        private float _transformX;
        private bool _isGrounded;
        
        private void Start()
        {
            _lookLeft = _player.transform.localScale;
            _lookRight = new Vector3(-_lookLeft.x, _lookLeft.y, _lookLeft.z);
        }
        private void Update()
        {
            Jump();
            HorizontalMove();
        }

        private void FixedUpdate()
        {
            SideTeleport();
            SpriteSwitch();
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
        private void Jump()
        {
            if (_player.velocity.y > _jumpPower)
                _isGrounded = false;
                
            if (_isGrounded)
            {
                _player.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
                _isGrounded = false;
            }
        }
        private void OnTriggerStay2D(Collider2D other)
        {
            if (_player.velocity.y <= _jumpPower / 3)
                _isGrounded = true;
        }

        private void SideTeleport()
        {
            _transformX = _player.transform.position.x;
            
            if (_transformX is >= 3f or <= -3f)
            {
                transform.Translate(-_transformX * 2, 0, 0);
            }
        }

        private void SpriteSwitch()
        {
            if (_player.velocity.y <= _jumpPower / 3)
            {
                _spriteIdle.SetActive(true);
                _spriteJump.SetActive(false);
            }
            else
            {
                _spriteIdle.SetActive(false);
                _spriteJump.SetActive(true);
            }
        }

    }
}
