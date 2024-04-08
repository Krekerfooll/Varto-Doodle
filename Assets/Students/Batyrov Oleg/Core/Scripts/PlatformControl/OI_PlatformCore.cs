using UnityEngine;

namespace OIMOD.Core.GameMech
{
    public abstract class OI_PlatformCore : MonoBehaviour
    {
        [Header("Init Setup")]
        [Space]
        [SerializeField] protected Transform _player;
        [SerializeField] protected Collider2D _platformCollider;
        [SerializeField] protected Transform _destroyDistance;
        [Header("For Complex Platforms")]
        [SerializeField] protected Rigidbody2D _playerRb;
        [SerializeField] protected float _playerJumpForce;
        [Space]
        [Header("TEST ONLY")]
        [Space]
        [SerializeField] protected bool _init;
        [SerializeField] protected int _jumpMultiplier;

        public virtual void Init(Transform player, Transform destroyDist, 
                Rigidbody2D _playerRigidBody, float _jumpPower, int _jumpMultiplier) {
            _player = player;
            _destroyDistance = destroyDist;
            _playerRb = _playerRigidBody;
            _playerJumpForce = _jumpPower * _jumpMultiplier;
            _init = true;
        }
        private void Update() {
            if (_init) {
                CollisionOnCheck();
                PlatformDestroyCheck();
            }
        }
        public virtual void CollisionOnCheck() 
        { 
            if (transform.position.y < _player.position.y) _platformCollider.enabled = true;
            else _platformCollider.enabled = false;
        }
        public virtual void PlatformDestroyCheck() { 
            var destroyY = _destroyDistance.position.y;
            var platformY = transform.position.y;

            if (destroyY > platformY)
                Destroy(gameObject);
        }
    }
}

