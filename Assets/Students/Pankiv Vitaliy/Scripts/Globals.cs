using UnityEngine;

namespace PVitaliy
{
    public abstract class Globals {
        public static bool IsSameLayer(int layer1, LayerMask layer2)
        {
            return (layer2 & (1 << layer1)) != 0;
        }

        public static bool IsPlayer(GameObject obj)
        {
            return obj.tag.Equals("Player");
        }
    }
}
