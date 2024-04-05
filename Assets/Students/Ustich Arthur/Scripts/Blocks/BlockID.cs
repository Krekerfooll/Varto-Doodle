using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class BlockID : MonoBehaviour
    {
        [SerializeField] private int _id;
        public int ID { get { return _id; } }
    }
}