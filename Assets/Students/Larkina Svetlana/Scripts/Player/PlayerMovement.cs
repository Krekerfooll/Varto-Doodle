using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _moveSpeed;
  
    private void Update()
    {
        var direction = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(direction * _moveSpeed, _rigidbody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }

    }
}
