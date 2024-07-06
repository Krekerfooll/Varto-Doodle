using UnityEngine;

namespace Alokhin.Stanislav.CloudMoves
{
    public class CloudMove : MonoBehaviour
    {
        [SerializeField] float _speed;
        [SerializeField] float _endPosX;
        [Space]
        [SerializeField] Color initiaalColor;
        //[SerializeField] Color middleColor;
        [SerializeField] Color finalColor;

        private SpriteRenderer _renderer;
        private float _startingTime;

        public void StartFloating(float speed, float endPosx)
        {
            _speed = speed; 
            _endPosX = endPosx;
            

        }
        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }
        private void Start()
        {
            _startingTime = Time.time;
        }
        void Update ()
        {
            transform.Translate(Vector3.right * (Time.deltaTime * _speed * (Random.Range(0.5f, 2.0f))));

            float _timeSinseStarted = Time.time - _startingTime;
            float _percentageCompleted = _timeSinseStarted / _endPosX;

            _renderer.color = Color.Lerp(initiaalColor, finalColor, _percentageCompleted);
            if(transform.position.x > _endPosX)
            {
                Destroy(gameObject);
            }
        }

    }
}

