using UnityEngine;

namespace Ustich.Arthur.Player
{
    public class BlockID : MonoBehaviour
    {
        [SerializeField] private int _id;
        public int ID { get { return _id; } }
    }
}