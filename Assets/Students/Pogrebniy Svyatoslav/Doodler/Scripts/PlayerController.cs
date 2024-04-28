using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 _playerPosition;
    [SerializeField]  private bool _groundCheck;
    private Vector2 reyLeft;
    private Vector2 reyRight;
    [SerializeField] private bool _isJump;
    [SerializeField] private LayerMask _groundMask ;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _reyLength;
    
    void FixedUpdate()
    {   
        _playerPosition = transform.position;
        var direction = Input.GetAxis("Horizontal");

        reyLeft = new(_playerPosition.x - 0.3f, _playerPosition.y);
        reyRight = new(_playerPosition.x + 0.3f, _playerPosition.y);
        _groundCheck = (Physics2D.Raycast(reyLeft, Vector2.down, _reyLength, _groundMask)) || (Physics2D.Raycast(reyRight, Vector2.down, _reyLength, _groundMask));
        Debug.DrawLine(reyLeft, reyLeft + Vector2.down * _reyLength, Color.magenta);
        Debug.DrawLine(reyRight, reyRight + Vector2.down * _reyLength, Color.magenta);

        if (_rb.velocity.y < 0.2f && _rb.velocity.y > -0.2f) { _isJump = true;}
        else { _isJump = false;}

        if (_groundCheck == true /*&& Input.GetKeyDown(KeyCode. Space)*/)
        {
            if (_isJump == true)
            {
                _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
                gameObject.GetComponent<RandomBackground>().ChangeColor();
            }
        }
        else if (_groundCheck == false && _isJump == false) 
            {
            _rb.velocity = new Vector2(direction * _moveSpeed, _rb.velocity.y);
            }
    }
}
