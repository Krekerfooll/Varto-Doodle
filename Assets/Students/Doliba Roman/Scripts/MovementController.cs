using UnityEngine;

namespace RomanDoliba.Player
{
    public class MovementController : MonoBehaviour
    {
        public bool _isGrounded;

        [SerializeField] private float _groundCheckDistance;
        [SerializeField] private Rigidbody2D _playerRigidbody;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private InputManager inputManager;
        [SerializeField] private SpriteRenderer _lookLeftRight;

        private void Start()
        {
            _lookLeftRight.flipX = true;

            if (PlayerPrefs.HasKey(GlobalData.PLAYER_POSITION))
            {
                transform.position = JsonUtility.FromJson<Vector3>(PlayerPrefs.GetString(GlobalData.PLAYER_POSITION));
            }
        }
        
        private void FixedUpdate()
        {
            _isGrounded = Physics2D.Raycast(_playerRigidbody.position, Vector2.down, _groundCheckDistance, _groundMask);
            Debug.DrawLine(_playerRigidbody.position, _playerRigidbody.position + Vector2.down * _groundCheckDistance, Color.red);
        }
        
        private void Update()
        { 
            if(inputManager.JumpInput && _isGrounded)
            {
                Jump();
            }
            else if(!_isGrounded)
            {
                Move();

                if (inputManager.MoveInput < 0f)
                {
                    _lookLeftRight.flipX = false;
                }
                else if (inputManager.MoveInput > 0f)
                {
                    _lookLeftRight.flipX = true;
                }
            }
            var playerPosition = JsonUtility.ToJson(transform.position);
            PlayerPrefs.SetString(GlobalData.PLAYER_POSITION, playerPosition);
        }

        private void Jump()
        {
            _playerRigidbody.AddForce(Vector2.up * GlobalData.PlayerJumpPower, ForceMode2D.Impulse);
        }
        private void Move()
        {
            _playerRigidbody.velocity = new Vector2(GlobalData.PlayerMoveSpeed * inputManager.MoveInput, _playerRigidbody.velocity.y);
        }
    }
}
