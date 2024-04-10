using UnityEngine;

namespace RomanDoliba.Utils
{
    public class PlayerKillOnCollision : MonoBehaviour
    {
        [SerializeField] private float _delay;
        private void OnCollisionEnter2D (Collision2D collision)
        {
            if (collision.gameObject.layer == 8)
            {
                Destroy (collision.gameObject, _delay);
            }
        }
    }
}
