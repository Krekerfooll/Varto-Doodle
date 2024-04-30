using System.Collections.Generic;
using UnityEngine;

namespace Examples.Player
{
    public class BafManager : MonoBehaviour
    {
        // Vocabulary for keeping track of the amount of each type of buff
        private Dictionary<BafType, int> bafCounts = new Dictionary<BafType, int>();

        void Awake()
        {
            // Initializing the Dictionary
            foreach (BafType type in System.Enum.GetValues(typeof(BafType)))
            {
                bafCounts[type] = 0;
            }
        }

        public void AddBaf(BafType type)
        {
            if (bafCounts.ContainsKey(type))
            {
                bafCounts[type]++;
                Debug.Log("Baf collected: " + type + ". Total: " + bafCounts[type]);
            }
        }
    }
}
