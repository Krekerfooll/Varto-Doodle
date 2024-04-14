using UnityEngine;

namespace Scripts
{
    public class PlatformBase : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        public int Health { get { return _health; } set { if (value >= 0) _health = value; } }
        bool firstStep = true;
        private float _color = 1f;



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
