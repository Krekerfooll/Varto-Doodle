using UnityEngine;

namespace Examples.Player
{
    public enum PlatformType
    {
        Standard,
        Ice,
        Moving,
        Breakable
    }

    public class PlatformTypeManager : MonoBehaviour
    {
        public GameObject[] platformPrefabs;  // Array of prefabs
                                              // Random platform prefab
        public GameObject GetRandomPlatformPrefab()
        {
            int index = Random.Range(0, platformPrefabs.Length);
            return platformPrefabs[index];
        }
    }
}
