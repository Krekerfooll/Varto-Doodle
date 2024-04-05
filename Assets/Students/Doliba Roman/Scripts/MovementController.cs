using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _groundCheckDistance;
    private bool _isGrounded;
    private bool _backgroundTriger;
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private InputManager inputManager;
    
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
        }
    }

    private void Jump()
    {
        _playerRigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
    }
    private void Move()
    {
        _playerRigidbody.velocity = new Vector2(_moveSpeed * inputManager.MoveInput, _playerRigidbody.velocity.y);
    }
}
