using Doodle.Utils;
using UnityEngine;

namespace Doodle.Core
{
    internal class Move : Action
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _movePower;

        private Vector3 _lookLeft;
        private Vector3 _lookRight;

        private void Start()
        {
            _lookLeft = _rigidbody.transform.localScale;
            _lookRight = new Vector3(-_lookLeft.x, _lookLeft.y, _lookLeft.z);
        }

        public override void Execute()
        {
            var moveDirection = Input.GetAxis("Horizontal");
            _rigidbody.velocity = new Vector2(moveDirection * _movePower, _rigidbody.velocity.y);

            if (moveDirection < 0) _rigidbody.transform.localScale = _lookLeft;
            else if (moveDirection > 0) _rigidbody.transform.localScale = _lookRight;
        }
    }
}
