using System.Linq;
using UnityEngine;
using static Varto.Examples.Data.PlatformsGroupData;

namespace Varto.Examples.Data
{
    [CreateAssetMenu(fileName = "PlatformsGenerationPattern", menuName = "Varto/PlatformsGenerationPattern", order = 0)]
    public class PlatformsGenerationPattern : ScriptableObject
    {
        [SerializeField] private PlatformsGroupSpawnData[] _platformsPattern;

        [System.NonSerialized] private Transform _target;
        [System.NonSerialized] private Transform _parent;
        [System.NonSerialized] private Vector2 _boundsX;

        public void Init(Transform target, Transform parent, Vector2 boundsX)
        {
            _target = target;
            _parent = parent;
            _boundsX = boundsX;
        }

        public GropSpawnResult SpawnNextGroup(float startSpawnHeight)
        {
            var randomGroup = GetRandomGroup();

            return randomGroup.SpawnGroup(_target, _parent, _boundsX, startSpawnHeight);
        }

        private PlatformsGroupData GetRandomGroup()
        {
            var chanceSum = _platformsPattern.Sum(pattern => pattern.Chance);
            var randomValue = Random.Range(0, chanceSum);

            var currentChance = 0;

            for (int i = 0; i < _platformsPattern.Length; i++)
            {
                currentChance += _platformsPattern[i].Chance;

                if (randomValue < currentChance)
                {
                    return _platformsPattern[i].Group;
                }
            }

            return _platformsPattern.Last().Group;
        }

        [System.Serializable]
        public struct PlatformsGroupSpawnData
        {
            public PlatformsGroupData Group;
            public int Chance;
        }
    }
}
