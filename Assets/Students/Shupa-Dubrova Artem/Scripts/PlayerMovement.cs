using System;
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
        [SerializeField] private float _jumpPowerSpring;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _groundCheckDistance;
        
        
        private Vector3 _lookLeft;
        private Vector3 _lookRight;

        private float _moveDirection;
        private float _transformX;
        private bool _setJump;
        private bool _setSpringJump;
        
        private void Start()
        {
            _lookLeft = _player.transform.localScale;
            _lookRight = new Vector3(-_lookLeft.x, _lookLeft.y, _lookLeft.z);
        }

        private void Update()
        {
            HorizontalMove();
        }

        private void FixedUpdate()
        {
            Jump();
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

        private void OnCollisionEnter2D(Collision2D other)
        {
            // if (other.CompareTag($"Spring") && _player.velocity.y <= _jumpPower / 3)
            //     _setSpringJump = true;
            // else if (_player.velocity.y <= _jumpPower / 3)
            //     _setJump = true;
            _setJump = true;
        }

        private void Jump()
        {
            // _setJump = Physics2D.Raycast(_player.position, Vector2.down, _groundCheckDistance, _groundMask);
            // Debug.DrawLine(_player.position, _player.position + Vector2.down * _groundCheckDistance, Color.magenta);
        
            if (_setJump && _player.velocity.y <= 0f)
            {
                Vector2 velocity = _player.velocity;
                velocity.y = _jumpPower;
                _player.velocity = velocity;
                _setJump = false;
            }
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
            var isSlowEnoughToIdle = _player.velocity.y <= _jumpPower / 3;
            
            _spriteIdle.SetActive(isSlowEnoughToIdle);
            _spriteJump.SetActive(!isSlowEnoughToIdle);
        }

    }
}
