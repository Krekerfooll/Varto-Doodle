using UnityEngine;

namespace Examples.Player
{
    public enum BafType
    {
        Sword,  
        Shield, 
        Bow,
        Spear 
    }

    public class BafItem : MonoBehaviour
    {
        public GameObject[] bafPrefabs;
        public BafType type;

        public BafType GetBafType()
        {
            return type;
        }

        public void UseBaf(BafType type)
        {
            if (bafPrefabs[(int)type] != null)
            {
                Instantiate(bafPrefabs[(int)type], transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogError("Baf prefab is missing for type: " + type);
            }
        }
    }
}
