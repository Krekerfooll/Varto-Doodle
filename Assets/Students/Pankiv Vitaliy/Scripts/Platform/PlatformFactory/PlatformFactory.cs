using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PVitaliy.Platform
{
    [CreateAssetMenu(fileName = "Platform", menuName = "Platform Factory")]
    public class PlatformFactory : ScriptableObject
    {
        public List<PlatformBase> platforms;
        public Vector2 verticalDistance;
        public Vector2 horizontalDistance;
        [Min(2)] public int maxPlatformCount = 8;
        public PlatformBase startingPlatform;

        public PlatformType GetRandomPlatformType()
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