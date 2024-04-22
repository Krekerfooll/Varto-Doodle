using UnityEngine;

namespace PVitaliy.Components
{
    public class ParallaxController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float parallaxDivider = 2;
        private void FixedUpdate()
        {
            var position = transform.position;
            var newY = target.position.y / parallaxDivider;
            transform.position = new Vector3(position.x, newY, position.z);
        }
    }
}