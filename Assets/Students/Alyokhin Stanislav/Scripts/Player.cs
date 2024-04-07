using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alokhin.Stanislav.Player
{
    
    public class Player : MonoBehaviour
    {
        [SerializeField] Rigidbody2D _rigidbody;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _jampPower;
        [SerializeField] private float _castLenght;

        private void Update()
        {
            bool isHit = Physics2D.Raycast(_rigidbody.transform.position, Vector2.down, _castLenght);
            Debug.DrawLine(_rigidbody.transform.position, _rigidbody.transform.position + Vector3.down * _castLenght, Color.red);

            var direction = Input.GetAxis("Horizontal");

            _rigidbody.velocity = new Vector2(direction * _moveSpeed, _rigidbody.velocity.y);

            if (_rigidbody.velocity.y == 0f && Input.GetKeyDown(KeyCode.W))
            {
                _rigidbody.AddForce(Vector2.up * _jampPower, ForceMode2D.Impulse);
            }
            
        }
    }
}

