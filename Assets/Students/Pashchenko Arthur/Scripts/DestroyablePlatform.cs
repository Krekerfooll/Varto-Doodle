using UnityEditor;
using UnityEngine;
namespace Artur.Pashchenko.Platform
{
    public class DestroyablePlatform : Platform
    {
        [SerializeField] private float _removalTime;
        [SerializeField] Rigidbody2D _playerRigidbody;
        [SerializeField] LayerMask _groundMask;
        [SerializeField] float _distanceForCast;
        private bool _isGrounded;
        private float _timer;

        private void FixedUpdate()
        {
            _isGrounded = Physics2D.Raycast(_playerRigidbody.position, Vector2.down, _distanceForCast, _groundMask);
            if (_isGrounded)
            {
                _timer += Time.deltaTime;

                if (_timer > _removalTime)
                {
                    Destroy(gameObject);
                }
            }
        }


    }
}