using UnityEngine;

namespace Examples.Player
{

    public class Platform : MonoBehaviour
    {
        [SerializeField] private GameObject target;
        [SerializeField] private GameObject[] bafPrefabs;

        void Start()
        {
            PlaceBafOnPlatform();
        }

        void PlaceBafOnPlatform()
        {
            if (bafPrefabs.Length > 0 && target.transform.childCount == 0)
            {
                if (Random.Range(0, 100) < 10) // 10% chance
                {
                    int bafIndex = Random.Range(0, bafPrefabs.Length);
                    GameObject bafPrefab = bafPrefabs[bafIndex];

                    if (bafPrefab != null)
                    {
                        // Create a buff directly on the target point
                        GameObject instantiatedBaf = Instantiate(bafPrefab, target.transform.position, Quaternion.identity, target.transform);
                        instantiatedBaf.GetComponent<BafItem>().type = (BafType)bafIndex; //Type
                    }
                    else
                    {
                        Debug.LogError("Baf prefab is missing");
                    }
                }
            }
            else
            {
                Debug.LogError("No prefabs assigned or target has children");
            }
        }
    }
}

