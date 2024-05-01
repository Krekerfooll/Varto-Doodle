using UnityEngine;

namespace VadymShvydkiy.PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb; 
        public Rigidbody2D Rb => _rb;
        [SerializeField] private float _speed;
        private float _speedDirection;
        public float SpeedDirection 
        { 
            set 
            { 
                value = value > 1 ? 1 : (value < -1 ? -1 : value);
                _speedDirection = value;
            } 
        }
        [SerializeField] private float _jumpSpeed;
        private bool _isCanJump;
        public bool IsCanJump { get { return _isCanJump;} set{_isCanJump = value;}}
        private bool _isRight = true; public bool IsRight
        {
            set
            {
                float y = transform.localScale.y;
                float z = transform.localScale.z;
                float x = Mathf.Abs(transform.localScale.x) * (value ? 1 : -1);
                transform.localScale = new Vector3(x, y, z);
                _isRight = value;
            }
        }
        [SerializeField] private BackgroundChangeManager _bgChangeManager;
        private void FixedUpdate()
        {
            FixedMove();
            if (_isCanJump)
            {
                FixedJump();
                _isCanJump = false;
                if (_bgChangeManager)
                    _bgChangeManager.CallChangeBackgroundColor();
            }
        }

        private void FixedMove()
        {
            _rb.velocity = new Vector2(_speed * _speedDirection, _rb.velocity.y);
        }
        private void FixedJump()
        {
            _rb.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        }
    }
}

