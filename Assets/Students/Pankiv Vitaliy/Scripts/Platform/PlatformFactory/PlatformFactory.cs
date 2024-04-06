using System;
using System.Collections.Generic;
using UnityEngine;

namespace PVitaliy.Platform
{
    [CreateAssetMenu(fileName = "Platform", menuName = "Platform Factory")]
    public class PlatformFactory : ScriptableObject // Запас на майбутнє, щоб потім не рефакторити ініціалізацію платформ :P
    {
        [SerializeField] public List<PlatformBase> platforms;
        public PlatformBase CreatePlatform(PlatformType type, PlatformController controller)
        {
            var platform = platforms.Find(platform => platform.Type == type);
            if (!platform)
            {
                throw new Exception("Platform " + type + " is not in the list");
            }
            platform.Init(controller);
            return platform;
        }
    }
}