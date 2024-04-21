using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Scripts
{
    public class PlatformMoving : PlatformBase
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector2 _wigth;

        private Vector2 targetPosition;
        private bool direction = true;
        void Update()
        {
            if (_isInitiated)
            {
                OnUpdatePlatform();
                MovingByX();
            }
        }

        private void MovingByX()
        {
            if (direction)
            {
                targetPosition = new Vector2(_wigth.x, transform.position.y);
                if(transform.position.x < _wigth.x + 0.5)
                {
                    direction = false;
                }
            } else
            {
                targetPosition = new Vector2(_wigth.y, transform.position.y);
                if (transform.position.x > _wigth.y - 0.5)
                {
                    direction = true;
                }
            }
                
            transform.position = Vector2.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
        }
    }
}
