using UnityEngine;

namespace PVitaliy.Utils
{
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float followingSpeed = 0.2f;

        private void FixedUpdate()
        {
            var initialPosition = transform.position;
            var newY = Mathf.Lerp(initialPosition.y, target.position.y, followingSpeed);
            transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
        }
    }
}