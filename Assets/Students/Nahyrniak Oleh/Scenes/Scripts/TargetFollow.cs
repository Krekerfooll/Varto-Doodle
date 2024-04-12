using UnityEngine;

namespace Doodle.Core
{
    internal class TargetFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _speed;

        private void Update()
        {
            FollowTargetByY(_target, _speed);
        }

        private void FollowTargetByY(Transform target, float followSpeed)
        {
            var targetPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed);
        }
    }
}
