using UnityEngine;

namespace Alokhin.Stanislav.CloudMoves
{
    public class CloudMove : MonoBehaviour
    {
        [SerializeField] float _speed;
        [SerializeField] float _endPosX;

        public void StartFloating(float speed, float endPosx)
        {
            _speed = speed; 
            _endPosX = endPosx;
            

        }
        void Update ()
        {
            transform.Translate(Vector3.right * (Time.deltaTime * _speed * (Random.Range(0.5f, 2.0f))));

            if(transform.position.x > _endPosX)
            {
                Destroy(gameObject);
            }
        }

    }
}

