using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _player;
        [SerializeField] private Vector2 _sideBounds;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _playerSpeed;
        [SerializeField] private float _jumpPower;
        [SerializeField] private LayerMask _onCollisionEnterWith;
        
        private Vector3 _lookLeft;
        private Vector3 _lookRight;

        private float _currentJumpPower;
        private float _moveDirection;
        private float _transformX;
        private bool _setJump;
        
        private void Start()
        {
            _currentJumpPower = _jumpPower;
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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if ((_onCollisionEnterWith.value & (1 << collision.gameObject.layer)) != 0)
            {
                _setJump = true;
            }
        }

        private void Jump()
        {
            if (_setJump && _player.velocity.y <= 0f)
            {
                Vector2 velocity = _player.velocity;
                velocity.y = _currentJumpPower;
                _player.velocity = velocity;
                _setJump = false;
            }
        }

        private void SideTeleport()
        {
            _transformX = _player.transform.position.x;
            
            if (_transformX > _sideBounds.y || _transformX < _sideBounds.x)
            {
                transform.Translate(-_transformX * 2, 0, 0);
            }
        }

        private void SpriteSwitch()
        {
            var isSlowEnoughToIdle = _player.velocity.y <= _jumpPower / 3;
            
            _animator.SetBool("isJumping", isSlowEnoughToIdle);
            _animator.SetBool("isJumping", !isSlowEnoughToIdle);
        }

        public void SetJumpPower(float buffJumpPower)
        {
            if (buffJumpPower > 0 && _currentJumpPower <= _jumpPower)
            {
                _currentJumpPower = buffJumpPower;
            }
            else
            {
                _currentJumpPower = _jumpPower;
            }
        }
    }
}
