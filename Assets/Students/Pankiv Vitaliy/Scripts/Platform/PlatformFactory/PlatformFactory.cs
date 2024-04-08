using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PVitaliy.Platform
{
    
    [CreateAssetMenu(fileName = "Platform", menuName = "Platform/Factory")]
    public class PlatformFactory : ScriptableObject
    {
        [Header("Platform Factory")]
        public List<PlatformBase> platforms;
        public PlatformBase startingPlatform;
        public Vector2 verticalDistance;
        public Vector2 horizontalDistance;
        [Min(2)] public int maxPlatformCount = 8;
        [Min(1)] public int preferredPlatformAmount = 8;
        [Min(0)] public float scoreMultiplier = 1;
        [Range(0, 1)] public float duplicateChance;
        
        public virtual void Init() {}
        public virtual PlatformType GetRandomPlatformType()
        {
            return platforms[Random.Range(0, platforms.Count)].Type;
        }
        public PlatformBase CreatePlatform(PlatformType type)
        {
            var platform = platforms.Find(platform => platform.Type == type);
            if (!platform)
            {
                throw new Exception("Platform " + type + " is not in the list");
            }
            return platform;
        }
    }
}