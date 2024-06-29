using System.Linq;
using UnityEngine;
using static Ustich.Arthur.DoodleJump.PlatformGroupData;

namespace Ustich.Arthur.DoodleJump
{
    [CreateAssetMenu(fileName = "Platform Generation Pattern", menuName = "Ustich/Platform Generation Pattern", order = 0)]

    public class PlatformGenerationPattern : ScriptableObject
    {
        [SerializeField] private PlatformsGroupSpawnData[] _platformPattern;

        [System.NonSerialized] private GameSettingsManager _gameSettingsManager;
        [System.NonSerialized] private Transform _parent;
        [System.NonSerialized] private Vector2 _boundsX;

        public void Init(GameSettingsManager gameSettingsManager, Transform parent, Vector2 boundsX)
        {
            _gameSettingsManager = gameSettingsManager;
            _parent = parent;
            _boundsX = boundsX;
        }

        public GroupSpawnResult SpawnNextGroup(float startSpawnHeight)
        {
            var randomGroup = GetRandomGroup();

            return randomGroup.SpawnGroup(_gameSettingsManager, _parent, _boundsX, startSpawnHeight);
        }

        private PlatformGroupData GetRandomGroup()
        {
            var chanceSum = _platformPattern.Sum(pattern => pattern.Chance);
            var randomValue = Random.Range(0, chanceSum);

            var currentChance = 0;

            for (int i = 0; i < _platformPattern.Length; i++)
            {
                currentChance += _platformPattern[i].Chance;

                if (randomValue < currentChance)
                {
                    Debug.Log($"Platform Group with index: {i} was spawned");
                    return _platformPattern[i].Group;
                }
            }

            Debug.Log($"Platform Group with index: {_platformPattern.Length - 1} was spawned");
            return _platformPattern.Last().Group;
        }


        [System.Serializable]
        public struct PlatformsGroupSpawnData
        {
            public PlatformGroupData Group;
            public int Chance;
        }
    }
}
