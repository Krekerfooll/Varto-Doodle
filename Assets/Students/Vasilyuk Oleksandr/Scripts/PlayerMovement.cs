using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] Animator _animator;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _moveSpeed;

    [SerializeField] private float _groundCheckDistance;
    private bool _isGrounded;
    [SerializeField] private Transform _player;
    [SerializeField] private LayerMask _isGroundedMask;



    void Update()
    {
        if (_player != null)
        {
            var direction = Input.GetAxis("Horizontal");
            if (direction >= 0f)
            {
                _player.localScale = new Vector3(1f, 1f);
                _rigidbody.linearVelocity = new Vector2(direction * _moveSpeed, _rigidbody.linearVelocity.y);
            }
            else
            {
                _player.localScale = new Vector3(-1f, 1f);
                _rigidbody.linearVelocity = new Vector2(direction * _moveSpeed, _rigidbody.linearVelocity.y);
            }

            if (Physics2D.Raycast(_player.position, Vector3.down, _groundCheckDistance, _isGroundedMask))
            {
                Debug.DrawLine(_player.position, _player.position + Vector3.down * _groundCheckDistance, Color.magenta);
                if (Input.GetKeyDown(KeyCode.W))
                {
                    _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
                }
            }
        }
        _animator.SetBool("isJumping", _rigidbody.linearVelocityY > 0.01f);
        _animator.SetBool("isFalling", _rigidbody.linearVelocityY < -0.01f);

        bool isIdle = Mathf.Abs(_rigidbody.linearVelocityY) < 0.01f;
        _animator.SetBool("isIdle", isIdle);
    }
}
