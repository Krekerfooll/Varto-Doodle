using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _moveSpeed;

    [SerializeField] private float _groundCheckDistance;
    private bool _isGrounded;
    [SerializeField] private Transform _player;
    [SerializeField] private LayerMask _isGroundedMask;



    void Update()
    {
        var direction = Input.GetAxis("Horizontal");
        if (direction>=0f)
        {
            _player.localScale = new Vector3(1f, 1f);
            _rigidbody.velocity = new Vector2(direction * _moveSpeed, _rigidbody.velocity.y);
        }
        else
        {
            _player.localScale = new Vector3(-1f, 1f);
            _rigidbody.velocity = new Vector2(direction * _moveSpeed, _rigidbody.velocity.y);
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
}
