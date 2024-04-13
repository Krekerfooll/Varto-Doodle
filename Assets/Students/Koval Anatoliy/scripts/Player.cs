using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpPower;
     [SerializeField] private float _moveSpeed;
     [SerializeField] private float groundCheckDistance;
     [SerializeField] private LayerMask _groundMask;
     private float direction;
     [SerializeField] private bool _isJump;
     private bool _isGrounded;
     private Vector3 _lookLeft;
     private Vector3 _lookRight;
    
    void Start()
    {
        _lookLeft = _rigidbody.transform.localScale;
        _lookRight = new Vector3(-_lookLeft.x, _lookLeft.y, _lookLeft.z);
    }

    private void Update()
    {
        CalculateJump();
        CalculateMove();
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.Raycast(_rigidbody.position, Vector2.down, groundCheckDistance, _groundMask);
        Debug.DrawLine(_rigidbody.position, _rigidbody.position + Vector2.down * groundCheckDistance, Color.magenta);

        if (_isGrounded)
        {
            if (_isJump)
            {
                _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
                _isJump = false;
            }
        }
        else _rigidbody.velocity = new Vector2(direction * _moveSpeed, _rigidbody.velocity.y);



    }

    private void CalculateJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJump = true;
        }
    }

    private void CalculateMove()
    {
        direction = Input.GetAxis("Horizontal");

        if (direction < 0f) _rigidbody.transform.localScale = _lookLeft;
        else if (direction > 0f) _rigidbody.transform.localScale = _lookRight;
    }

    



}
