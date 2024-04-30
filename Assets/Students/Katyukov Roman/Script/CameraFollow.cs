using UnityEngine;

namespace Examples.Player
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float verticalOffset = 1.0f;
        [SerializeField] private float followSpeed = 2.0f;
        [SerializeField] private float minYPosition = 0.0f;

        public Transform Target => target;

        private void Update()
        {
            if (target != null)
            {
                var targetPosition = new Vector3(transform.position.x, target.position.y + verticalOffset, transform.position.z);
                targetPosition.y = Mathf.Max(targetPosition.y, minYPosition);
                transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            }
        }
    }
}