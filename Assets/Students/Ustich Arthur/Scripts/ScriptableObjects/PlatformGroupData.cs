using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    //[CreateAssetMenu(fileName = "Platform Group", menuName = "Ustich/Platform Group", order = 1)]
    public class PlatformGroupData : ScriptableObject
    {
        [SerializeField] private PlatfowmRow[] _platfornsGroup;
        [SerializeField] private Vector2 _heightBounds;

        public GroupSpawnResult SpawnGroup(GameSettingsManager gameSettingsManager, Transform parent, Vector2 boundX, float startSpawnHeight)
        {
            var spawnedPlatforms = new List<BasePlatform>();
            var lastSpawnedHeight = 0f;

            for (int i = 0; i < _platfornsGroup.Length; i++)
            {
                var row = _platfornsGroup[i];
                lastSpawnedHeight = i == 0 ? startSpawnHeight : lastSpawnedHeight + Random.Range(_heightBounds.x, _heightBounds.y);
                var spawnedRow = row.SpawnRow(gameSettingsManager, parent, boundX, lastSpawnedHeight);

                spawnedPlatforms.AddRange(spawnedRow);
            }

            return new GroupSpawnResult(spawnedPlatforms, lastSpawnedHeight);
        }


        public struct GroupSpawnResult
        {
            public readonly List<BasePlatform> SpawnedPlatforms;
            public readonly float LastSpawnedHeight;

            public GroupSpawnResult(List<BasePlatform> spawnedPlatfowms, float lastSpawnedHeight)
            {
                SpawnedPlatforms = spawnedPlatfowms;
                LastSpawnedHeight = lastSpawnedHeight;
            }
        }

        [System.Serializable]
        public struct PlatfowmRow
        {
            public BasePlatform[] Platforms;

            public List<BasePlatform> SpawnRow(GameSettingsManager gameManager, Transform parent, Vector2 boundX, float spawnHeight)
            {
                var spawnedPlatforms = new List<BasePlatform>();

                for (int i = 0; i < Platforms.Length; i++)
                {
                    var platformPositionX = Random.Range(boundX.x, boundX.y);
                    var platformPosition = new Vector3(platformPositionX, spawnHeight, parent.position.z);

                    var spawnedPlatform = Instantiate(Platforms[i], platformPosition, Quaternion.identity, parent);
                    spawnedPlatform.Init(gameManager);

                    spawnedPlatforms.Add(spawnedPlatform);
                }

                return spawnedPlatforms;
            }
        }
    }
}