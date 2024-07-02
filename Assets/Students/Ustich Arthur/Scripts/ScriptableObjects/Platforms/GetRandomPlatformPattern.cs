using System.Linq;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    [CreateAssetMenu(fileName = "GetRandomPlatformPattern", menuName = "Ustich/Patterns/GetRandomPlatformPattern", order = 0)]
    public class GetRandomPlatformPattern : ScriptableObject
    {
        [SerializeField] private PlatformSpawnChance[] _platformSpawnChances;

        public GameObject SpawnRandomPlatform(GameObject Target, Vector2 Position, Transform Parent)
        {
            return GetRandomPlatform().SpawnPlatform(Target, Position, Parent);
        }

        private PlatformData GetRandomPlatform()
        {
            var chanceSum = _platformSpawnChances.Sum(pattern => pattern.Chance);
            var randomValue = Random.Range(0, chanceSum);

            var currentChance = 0;

            for (int i = 0; i < _platformSpawnChances.Length; i++)
            {
                currentChance += _platformSpawnChances[i].Chance;

                if (randomValue < currentChance)
                {
                    Debug.Log($"Platforms Group with index: {i} was spawned");
                    return _platformSpawnChances[i].Platform;
                }
            }

            Debug.Log($"Platforms Group with index: {_platformSpawnChances.Length - 1} was spawned");
            return _platformSpawnChances.Last().Platform;
        }

        [System.Serializable]
        public struct PlatformSpawnChance
        {
            public PlatformData Platform;
            public int Chance;
        }
    }
}