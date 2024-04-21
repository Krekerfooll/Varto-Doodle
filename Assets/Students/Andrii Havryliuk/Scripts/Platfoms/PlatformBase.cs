using Unity.VisualScripting;
using UnityEngine;

namespace Scripts
{
    public class PlatformBase : MonoBehaviour
    {
        
        [SerializeField] protected int _health;
        [Space]
        [SerializeField] protected SpriteRenderer _spriteRenderer;
        [SerializeField] protected BoxCollider2D _collider;
        [SerializeField] protected PlatformCollider _platformCollider;

        protected Transform _target;

        public int Health 
        { 
            get => _health;  
            set { _health = Mathf.Max(value, 0); } 
        }

        protected bool firstStep = true;
        protected float _color = 1f;

        public bool _isInitiated {get; private set;}

        public void Init(Transform target)
        {
            _target = target;
            _isInitiated = true;
        }

        private void Update()
        {
            if (_isInitiated)
            {
                OnUpdatePlatform();
            }
        }


        protected void OnUpdatePlatform()
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
    }
}
