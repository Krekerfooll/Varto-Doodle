using UnityEngine;

namespace Scripts
{
    public class PlatformBase : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        public int Health { get { return _health; } set { if (value >= 0) _health = value; } }

        private float _color = 1f;



        void OnCollisionEnter2D(Collision2D collision)
        {
            if (Health > 0)
            {
                ColorController.ChangeColor(_spriteRenderer, ref _color);
                Health--;
            }
        }
    }
}
