using System.Collections;
using System.Collections.Generic;
using RomanDoliba.Platform;
using UnityEngine;

namespace RomanDoliba.Data
{
    [CreateAssetMenu(fileName = "PlatformsGroup", menuName = "MyData/PlatformsGroup", order = 1)]
    public class PlatformGroupData : ScriptableObject
    {
        [SerializeField] private PlatformRow[] _platformRows;
        [SerializeField] private Vector2 _heightBounds;

        public GroupSpawnResult SpawnGroup(Transform target, Transform parent, Vector2 boundsX, float startSpawnHeight)
        {
            var spawnedPlatforms = new List<PlatformBase>();
            var lastSpawnedHeight = 0f;

            for (int i = 0; i < _platformRows.Length; i++)
            {
                var row = _platformRows[i];
                lastSpawnedHeight = i == 0 ? startSpawnHeight : lastSpawnedHeight + Random.Range(_heightBounds.x, _heightBounds.y);
                var spawnedRow = row.SpawnRow(target, parent, boundsX, lastSpawnedHeight);

                spawnedPlatforms.AddRange(spawnedRow);
            }
            return new GroupSpawnResult(spawnedPlatforms, lastSpawnedHeight);
        }
        public struct GroupSpawnResult
        {
            public readonly List<PlatformBase> SpawnedPlatforms;
            public readonly float LastSpawnedHeight;
            public GroupSpawnResult(List<PlatformBase> spawnedPlatforms, float lastSpawnedHeight)
            {
                SpawnedPlatforms = spawnedPlatforms;
                LastSpawnedHeight = lastSpawnedHeight;
            }
        }
        [System.Serializable]
        public struct PlatformRow
        {
            public PlatformBase[] Platforms;

            public List<PlatformBase> SpawnRow(Transform target, Transform parent, Vector2 boundsX, float spawnHeight)
            {
                var spawnedPlatforms = new List<PlatformBase>();

                for (int i = 0; i < Platforms.Length; i++)
                {
                    var platformPositionX = Random.Range(boundsX.x, boundsX.y);
                    var platformPosition = new Vector3(platformPositionX, spawnHeight, parent.position.z);

                    var spawnedPlatform = Instantiate(Platforms[i], platformPosition, Quaternion.identity, parent);
                    spawnedPlatform.Init(target);

                    spawnedPlatforms.Add(spawnedPlatform);
                }
                return spawnedPlatforms;
            }

        }
    }
}
    
