using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class PlatformDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Block")
                Destroy(collision.gameObject);
        }
    }
}