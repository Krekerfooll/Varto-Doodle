using UnityEngine;

namespace PVitaliy.Utils
{
    public abstract class StaticUtils {
        public static bool IsSameLayer(int layer1, LayerMask layer2)
        {
            return (layer2 & (1 << layer1)) != 0;
        }
    }
}
