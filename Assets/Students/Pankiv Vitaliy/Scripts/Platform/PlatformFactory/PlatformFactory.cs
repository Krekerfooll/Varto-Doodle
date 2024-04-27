using PVitaliy.Factory;
using PVitaliy.Utils;
using UnityEngine;

namespace PVitaliy.Platform
{
    
    [CreateAssetMenu(fileName = "Platform", menuName = "Platform/Factory")]
    public class PlatformFactory : FactoryBase<PlatformBase, PlatformType>
    {
        [Header("Platform Factory")]
        public PlatformBase startingPlatform;
        public MinMax<float> verticalDistance;
        public MinMax<float> horizontalDistance;
        [Min(1)] public int preferredPlatformAmount = 6;
        [Min(0)] public float scoreMultiplier = 1;
        [Range(0, 1)] public float duplicateChance;
        
        public override void Init() {}
    }
}