using PVitaliy.Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PVitaliy.Platform
{
    public class HorizontallyMovingPlatform : PlatformStatic
    {
        [Header("Horizontal Moving Platform")]
        [SerializeField] private float minSpeed = 1f;
        [SerializeField] private float maxSpeed = 2f;
        [SerializeField] private Rigidbody2D rigidBody;
        private Transform _leftPoint;
        private Transform _rightPoint;
        private Collider2D _standingPlayerCollider2D;
        private float _speed;
        protected int CurrentDirectionX;
        public override PlatformType Type => PlatformType.HorizontalMoving;

        protected override void AfterInit()
        {
            _leftPoint = Controller.MovingPlatformsBoundsLeft;
            _rightPoint = Controller.MovingPlatformsBoundsRight;
            base.AfterInit();
        }

        private void Awake()
        {
            _speed = Random.Range(minSpeed, maxSpeed);
            CurrentDirectionX = Random.value > .5 ? -1 : 1;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            rigidBody.velocity = new Vector2(CurrentDirectionX * _speed, 0); //TODO: зробити анімацією (мабуть)
            ChangeDirectionIfCan();
        }

        private void ChangeDirectionIfCan()
        {
            if (CurrentDirectionX == -1 && transform.position.x <= _leftPoint.position.x) CurrentDirectionX = 1; 
            else if (transform.position.x >= _rightPoint.position.x) CurrentDirectionX = -1;
        }

        protected override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            MoveStandingPlayer();
        }

        protected virtual void MoveStandingPlayer()
        {
            if (!_standingPlayerCollider2D) return;
            if (!_collider.IsTouching(_standingPlayerCollider2D))
            {
                _standingPlayerCollider2D = null;
                return;
            }

            var playerVelocity = _standingPlayerCollider2D.attachedRigidbody.velocity;
            _standingPlayerCollider2D.attachedRigidbody.velocity = new Vector2(playerVelocity.x == 0 ? rigidBody.velocity.x : playerVelocity.x, playerVelocity.y);
        }

        protected override void OnPlayerLanded(PlayerMovement player)
        {
            base.OnPlayerLanded(player);
            _standingPlayerCollider2D = player.GetComponent<Collider2D>();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(Vector3.right * _leftPoint.position.x + Vector3.up * transform.position.y,
                Vector3.right * _rightPoint.position.x + Vector3.up * transform.position.y);
        }
    }
}