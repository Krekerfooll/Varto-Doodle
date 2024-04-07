using System;
using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts
{
    public class PlatformSpring : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _player;
        [SerializeField] private float _jumpPower;

        private bool _setJump;

        private void Update()
        {
            Jump();
        }
        private void Jump()
        {
            if (_setJump)
            {
                _player.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
                _setJump = false;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            _setJump = true;
        }
    }
}
