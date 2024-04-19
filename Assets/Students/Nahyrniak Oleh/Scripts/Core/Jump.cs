using Doodle.Utils;
using UnityEngine;

namespace Doodle.Core
{
    internal class Jump : Action
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        [SerializeField] private float _jumpPower;
        [SerializeField] private KeyCode _key;
        public override void Execute()
        {
            if (Input.GetKeyDown(_key)) _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }
}
