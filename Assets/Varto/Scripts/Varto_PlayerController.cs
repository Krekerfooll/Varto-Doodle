using System;
using UnityEngine;
using Varto.Examples.Utils;

namespace Varto.Examples.Player
{
    public class Varto_PlayerController : MonoBehaviour
    {
        public event Action<Vector3> OnLanded;

        [SerializeField] private Rigidbody2D _player;
        [Space]
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpPower;
        [Space]
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _groundCheckDistance;
        [Space]
        [SerializeField] private Varto_ActionBase _onPlayerDie;
        [SerializeField] private Varto_ActionBase _onPlayerJump;

        private Vector3 _lookLeft;
        private Vector3 _lookRight;

        private float _moveDirection;
        private bool _isJump;
        private bool _isGrounded;
        private bool _wasGroundedLastFrame;

        public Vector3 Position => transform.position;
        public void SetPosition(Vector3 pos) => transform.position = pos;

        public void Init()
        {
            _lookLeft = _player.transform.localScale;
            _lookRight = new Vector3(-_lookLeft.x, _lookLeft.y, _lookLeft.z);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
                _isJump = true;

            _moveDirection = Input.GetAxis("Horizontal");
            if (_moveDirection < 0f) _player.transform.localScale = _lookLeft;
            else if (_moveDirection > 0f) _player.transform.localScale = _lookRight;
        }

        private void FixedUpdate()
        {
            _isGrounded = Physics2D.Raycast(_player.position, Vector2.down, _groundCheckDistance, _groundMask);

            if (_isGrounded && !_wasGroundedLastFrame)
                OnLanded?.Invoke(transform.position);

            _wasGroundedLastFrame = _isGrounded;

            Debug.DrawLine(_player.position, _player.position + Vector2.down * _groundCheckDistance, Color.magenta);

            if (_isGrounded)
            {
                if (_isJump)
                {
                    _onPlayerJump.Execute();
                    _player.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
                    _isJump = false;
                }
            }
            else
            {
                _player.velocity = new Vector2(_speed * _moveDirection, _player.velocity.y);
            }
        }
    }
}
