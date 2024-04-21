using UnityEngine;

namespace Alokhin.Stanislav.CloudMove
{
    public class CloudMove : MonoBehaviour
    {
        [SerializeField] float _speed;
        [SerializeField] Vector2 _resetPosition;
        void Update()
        {
            //transform.position = Camera.main.transform.position + _resetPosition;

            //_resetPosition.x += _speed * Time.deltaTime;
           transform.Translate(Vector2.right * _speed * Time.deltaTime);
           if (transform.position.x > _resetPosition.x)
           {
               transform.position = new Vector3(_resetPosition.x, _resetPosition.y);
           }
        }
    }
}

