using System.Collections.Generic;
using UnityEngine;
using Varto.Examples.Platforms;

namespace Varto.Examples.Data
{
    [CreateAssetMenu(fileName = "PlatformsGroup", menuName = "Varto/PlatformsGroup", order = 1)]
    public class PlatformsGroupData : ScriptableObject
    {
        [SerializeField] private PlatformRow[] _platformsGroup;
        [SerializeField] private Vector2 _heightBounds;

        public GropSpawnResult SpawnGroup(Transform target, Transform parent, Vector2 boundsX, float startSpawnHeight)
        {
            var spawnedPlatforms = new List<Varto_Platform>();
            var lastSpawnedHeight = 0f;

            for (int i = 0; i < _platformsGroup.Length; i++)
            {
                var row = _platformsGroup[i];
                lastSpawnedHeight = i == 0 ? startSpawnHeight : lastSpawnedHeight + Random.Range(_heightBounds.x, _heightBounds.y);
                var spawnedRow = row.SpawnRow(target, parent, boundsX, lastSpawnedHeight);

                spawnedPlatforms.AddRange(spawnedRow);
            }

            return new GropSpawnResult(spawnedPlatforms, lastSpawnedHeight);
        }

        public readonly struct GropSpawnResult
        {
            public readonly List<Varto_Platform> SpawnedPlatforms;
            public readonly float LastSpawnedHeight;

            public GropSpawnResult(List<Varto_Platform> spawnedPlatforms, float lastSpawnedHeight)
            {
                SpawnedPlatforms = spawnedPlatforms;
                LastSpawnedHeight = lastSpawnedHeight;
            }
        }

        [System.Serializable]
        public struct PlatformRow
        {
            public Varto_Platform[] Platforms;

            public List<Varto_Platform> SpawnRow(Transform target, Transform parent, Vector2 boundsX, float spawnHeight)
            {
                var spawnedPlatforms = new List<Varto_Platform>();

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
