using System.Linq;
using UnityEngine;
using static RomanDoliba.Data.PlatformGroupData;

namespace RomanDoliba.Data
{
    [CreateAssetMenu(fileName = "PlatformsGenerationPatern", menuName = "MyData/PlatformsGenerationPatern", order = 2)]
    public class PlatformsGenerationPatern : ScriptableObject
    {
        [SerializeField] private PlatformsGroupSpawnData[] _platformsPatterns;

        [System.NonSerialized] private Transform _target;
        [System.NonSerialized] private Transform _parent;
        [System.NonSerialized] private Vector2 _boundsX;

        public void Init(Transform target, Transform parent, Vector2 boundsX)
        {
            _target = target;
            _parent = parent;
            _boundsX = boundsX;
        }

        public GroupSpawnResult SpawnNextGroup(float startSpawnHeight)
        {
            var randomGroup = GetRandomGroup();
            return randomGroup.SpawnGroup(_target, _parent, _boundsX, startSpawnHeight);
        }

        public PlatformGroupData GetRandomGroup()
        {
            var chanceSum = _platformsPatterns.Sum(pattern => pattern.Chance);
            var randomValue = Random.Range(0, chanceSum);
            var currentChance = 0;

            for (int i = 0; i < _platformsPatterns.Length; i++)
            {
                currentChance += _platformsPatterns[i].Chance;

                if (randomValue < currentChance)
                {
                    return _platformsPatterns[i].Group;
                }
            }
            return _platformsPatterns.Last().Group;
        }

        [System.Serializable]
        public struct PlatformsGroupSpawnData
        {
            public PlatformGroupData Group;
            public int Chance;
        }
    }
}
