using Examples.Player;
using UnityEngine;

namespace Examples.Player
{

    public class BuffCollector : MonoBehaviour
    {
        public string buffName; // Name of the buff, used for the event

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")) // Ensure the collider has the tag "Player"
            {
                GlobalEventSender.FireEvent(buffName);
                Destroy(gameObject); // Destroy the buff object
            }
        }
    }
}
