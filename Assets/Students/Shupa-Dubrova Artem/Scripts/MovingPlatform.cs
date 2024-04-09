using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _platform;
        [SerializeField] private Vector2 _boundsX;
        [SerializeField] private float _speed;
        
        private int _moveDirectionX = -1;
        void FixedUpdate()
        {
            PlatformMove();
        }

        private void PlatformMove()
        {
            if (transform.position.x < _boundsX.x)
                _moveDirectionX = 1;
            else if (transform.position.x > _boundsX.y)
                _moveDirectionX = -1;
            _platform.velocity = new Vector2(_moveDirectionX * _speed, _platform.velocity.y);
        }
    }
    
}
