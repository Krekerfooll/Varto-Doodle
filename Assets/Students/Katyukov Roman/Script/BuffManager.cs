using UnityEngine;

namespace Examples.Player
{
    public class BuffManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] buffPrefabs; // Array of potential buffs to spawn
        [SerializeField] public Transform target; // The target location for spawning the buff

        private void Awake()
        {

            Execute();
        }

        public void Execute()
        {
            if (buffPrefabs.Length == 0)
                return;

            // Select one random buff from the list
            GameObject selectedBuffPrefab = buffPrefabs[Random.Range(0, buffPrefabs.Length)];
            InstantiateBuff(selectedBuffPrefab);
        }

        private void InstantiateBuff(GameObject buffPrefab)
        {
            if (target == null)
                return;

            // Instantiate the selected buff at the target position
            GameObject buffInstance = Instantiate(buffPrefab, target.position, Quaternion.identity, transform);

            // Check if BuffCollector already exists on the instantiated buff
            BuffCollector collector = buffInstance.GetComponent<BuffCollector>();
            if (collector == null)
            {
                // If not, add BuffCollector dynamically
                collector = buffInstance.AddComponent<BuffCollector>();
            }

            // Setup or update BuffCollector properties as necessary
            collector.buffName = "Buff_" + buffPrefab.name; // Set a unique name for the event
        }
    }
}
