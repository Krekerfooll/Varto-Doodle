using Doodle.Utils;
using UnityEngine;

namespace Doodle.Core
{
    internal class TargetFollow : Action
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _speed;
        
        [SerializeField] private bool _followX;
        [SerializeField] private bool _followY;
        [SerializeField] private bool _followZ;

        public override void Execute()
        {
            var targetPosition = new Vector3
            (
                _followX ? _target.position.x : transform.position.x,
                _followY ? _target.position.y : transform.position.y,
                _followZ ? _target.position.z : transform.position.z
            );

            transform.position = Vector3.Lerp(transform.position, targetPosition, _speed);
        }
    }
}
