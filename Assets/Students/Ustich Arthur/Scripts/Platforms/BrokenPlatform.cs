using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class BrokenPlatform : BasePlatform
    {
        private float _delay = 1f;


        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Collision");
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("Player Collision");
                Destroy(gameObject, _delay);
            }
        }
    }
}
