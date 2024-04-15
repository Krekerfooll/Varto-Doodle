using UnityEngine;

namespace RomanDoliba.Utils
{
    public class FollowTarget : ActionBase
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _speed;
        [SerializeField] bool _followByX;
        [SerializeField] bool _followByY;
        [SerializeField] bool _followByZ;

        private void Update()
        {
           Execute();
        }

        protected override void Execute()
        {
             var targetPosition = new Vector3(
                _followByX ? _target.position.x : transform.position.x,
                _followByY ? _target.position.y : transform.position.y,
                _followByZ ? _target.position.z : transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
        }
    }
}
