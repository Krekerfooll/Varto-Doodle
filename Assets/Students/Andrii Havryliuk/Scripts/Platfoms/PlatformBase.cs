using Unity.VisualScripting;
using UnityEngine;

namespace Scripts
{
    public class PlatformBase : MonoBehaviour
    {
        
        [SerializeField] private int _health;
        [Space]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BoxCollider2D _collider;
        [SerializeField] private PlatformCollider _platformCollider;
        
        private Transform _target;

        public int Health 
        { 
            get => _health;  
            set { _health = Mathf.Max(value, 0); } 
        }

        bool firstStep = true;
        private float _color = 1f;

        public bool _isInitiated {get; private set;}

        public void Init(Transform target)
        {
            _target = target;
            _isInitiated = true;
        }

        void Update()
        {
            if (_isInitiated)
            {
                OnUpdatePlatform();
            }
        }


        private void OnUpdatePlatform()
        {
            if (_target.position.y > transform.position.y)
            {
                _collider.enabled = true;
            } else _collider.enabled = false;
            if(_platformCollider.OnCollisin) 
            {
                if (firstStep)
                {
                    ColorController.ChangeColorForCameraBackgroundByRandom();
                    firstStep = false;
                }
                if (Health > 0)
                {
                    ColorController.ChangeColorByStep(_spriteRenderer, ref _color, 0.3f);
                    Health--;
                }
            }
        }

        
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (firstStep)
            {
                ColorController.ChangeColorForCameraBackgroundByRandom();
                firstStep = false;
            }
            if (Health > 0)
            {
                ColorController.ChangeColorByStep(_spriteRenderer, ref _color, 0.3f);
                Health--;
            }
        }

    }
}
