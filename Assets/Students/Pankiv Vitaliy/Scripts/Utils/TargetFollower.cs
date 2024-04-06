using UnityEngine;

namespace PVitaliy.Utils
{
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float followingSpeed = 0.2f;

        private void Update()
        {
            var position = transform.position;
            var newY = Mathf.Lerp(position.y, target.position.y, followingSpeed * Time.deltaTime);
            transform.position = new Vector3(position.x, newY, position.z);
        }
    }
}