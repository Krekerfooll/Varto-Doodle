using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Camera
{
    public class BackgroundPosition : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _speed;
        
        private void FixedUpdate()
        {
            BackgroundMove();
        }

        private void BackgroundMove()
        {
            var startPoint = -_target.position.y * _speed;
            transform.localPosition = new Vector3(0, startPoint, 10);
        }
    }
}
