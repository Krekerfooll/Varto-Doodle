using PVitaliy.Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PVitaliy.Platform
{
    public class HorizontallyMovingPlatform : PlatformStatic
    {
        [SerializeField] private float minSpeed = 1f;
        [SerializeField] private float maxSpeed = 2f;
        [SerializeField] private Rigidbody2D rigidBody;
        private Transform _leftPoint;
        private Transform _rightPoint;
        private Collider2D _standingPlayerCollider2D;
        private float _previousPositionX;
        private float _speed;
        protected int CurrentDirectionX;
        public override PlatformType Type => PlatformType.HorizontalMoving;

        protected override void AfterInit()
        {
            _previousPositionX = transform.position.x;
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
            if (CurrentDirectionX == -1)
            {
                if (transform.position.x <= _leftPoint.position.x)
                {
                    CurrentDirectionX = 1;
                }

                return;
            }

            if (transform.position.x >= _rightPoint.position.x)
            {
                CurrentDirectionX = -1;
            }
        }

        protected override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            MoveStandingPlayer();
            _previousPositionX = transform.position.x;
        }

        protected virtual void MoveStandingPlayer()
        {
            if (!_standingPlayerCollider2D) return;
            if (!_collider.IsTouching(_standingPlayerCollider2D))
            {
                _standingPlayerCollider2D = null;
                return;
            }

            var distance = transform.position.x - _previousPositionX;
            _standingPlayerCollider2D.transform.position += Vector3.right * distance;
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