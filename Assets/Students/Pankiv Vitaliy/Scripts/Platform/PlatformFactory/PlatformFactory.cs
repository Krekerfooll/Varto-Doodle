using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PVitaliy.Platform
{
    [CreateAssetMenu(fileName = "Platform", menuName = "Platform Factory")]
    public class PlatformFactory : ScriptableObject // Запас на майбутнє, щоб потім не рефакторити ініціалізацію та різні типи платформ для сцен :P
    {
        [SerializeField] public List<PlatformBase> platforms;

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