using UnityEngine;
using VadymShvydkiy.PlayerMovement;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _groundCheckDistanceForJump;
    [SerializeField] private float _groundCheckDistanceForLand;
    [SerializeField] private Animator animator;
    private bool _lastDirectionWasRight = true;
    private bool _isGrounded = true;
    void Update()
    {
        SetIsJump();
        SetHorizontalDirection();
    }

    private void SetIsJump()
    {
        _isGrounded = Physics2D.Raycast(_playerMovement.Rb.position, Vector2.down, _groundCheckDistanceForJump, _groundMask);
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _playerMovement.IsCanJump = true;
            animator.SetTrigger("Jump");
        }
    }

    private void SetHorizontalDirection()
    {
        if (_playerMovement)
        {
            var _speedDirection = Input.GetAxis("Horizontal");
            _playerMovement.SpeedDirection = _speedDirection;
            var _isRight = (_speedDirection > 0) ? true : (_speedDirection < 0 ? false : _lastDirectionWasRight);
            if (_isRight != _lastDirectionWasRight)
            {
                _lastDirectionWasRight = _isRight;
                _playerMovement.IsRight = _isRight;
            }
            bool _isInputKeyDown = IsInputKeyDown();
            bool _isInputKeyUp = IsInputKeyUp();
            if (_isGrounded)
            {
                if (_isInputKeyDown)
                    animator.SetBool("isRunning", true);
                else if(_isInputKeyUp)
                    animator.SetBool("isRunning", false);
            }
            
        }
    }
    private bool IsInputKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
            return true;
        else
            return false;
    }
    private bool IsInputKeyUp()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) ||
            Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            return true;
        else
            return false;
    }
    
}
