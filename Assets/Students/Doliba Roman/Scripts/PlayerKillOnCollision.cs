using UnityEngine;

namespace RomanDoliba.Utils
{
    public class PlayerKillOnCollision : MonoBehaviour
    {
        [SerializeField] private float _delay;
               
        private void OnTriggerEnter2D (Collider2D collider)
        {
            if (collider.gameObject.layer == 8)
            {
                Destroy (collider.gameObject, _delay);
            }
        }
    }
}
