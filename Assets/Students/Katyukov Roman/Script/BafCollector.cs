using UnityEngine;

namespace Examples.Player
{
    [SerializeField]
    public class BafCollector : MonoBehaviour
    {
        private BafManager bafManager;

        void Start()
        {
            bafManager = FindObjectOfType<BafManager>();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                BafItem bafItem = other.gameObject.GetComponent<BafItem>();
                if (bafItem != null)
                {
                    // Getting the buff type from the object
                    BafType bafType = bafItem.GetBafType();
                    // Adding a buff to the manager
                    bafManager.AddBaf(bafType);
                    // Deactivating the buff object
                    gameObject.SetActive(false);
                }
            }
        }
    }
}