using PVitaliy.Factory;
using UnityEngine;

namespace PVitaliy.Platform
{
    
    [CreateAssetMenu(fileName = "Platform", menuName = "Platform/Factory")]
    public class PlatformFactory : FactoryBase<PlatformBase, PlatformType>
    {
        [Header("Platform Factory")]
        public PlatformBase startingPlatform;
        public Vector2 verticalDistance;
        public Vector2 horizontalDistance;
        [Min(2)] public int maxPlatformCount = 16;
        [Min(1)] public int preferredPlatformAmount = 6;
        [Min(0)] public float scoreMultiplier = 1;
        [Range(0, 1)] public float duplicateChance;
        
        public override void Init() {}
    }
}