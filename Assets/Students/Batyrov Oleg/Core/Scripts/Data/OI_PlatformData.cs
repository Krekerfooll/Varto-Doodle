using UnityEngine;

namespace OIMOD.Core.Component
{
    [System.Serializable]
    public class OI_PlatformData
    {
        public GameObject platformPrefab;
        [Range(0,100)] public int spawnRate;
        [Range(0, 10)] public int stepsToSpawn;
        public int currentStep;
        public bool isSimple;
        public bool isSmall;
        public bool isHighJump;
        public bool isSimpleBroken;
        public bool isSmallBroken;
        public bool isDeadly;
    }
}

