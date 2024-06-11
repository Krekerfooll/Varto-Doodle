using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Varto.Examples.Data;

namespace Varto.Examples.Platforms
{
    public class Varto_PlatformGenerator : MonoBehaviour
    {
        [Header("Global Settings:")]
        [Space]
        [SerializeField] private Transform _target;
        [Space]
        [Header("Spawn Settings:")]
        [Space]
        [SerializeField] private PlatformsGenerationPattern _spawnPattern;
        [SerializeField] private float _spawnOffset;
        [SerializeField] private float _destroyOffset;
        [SerializeField] private float _groupStepHeight;
        [SerializeField] private Vector2 _bounds;

        private List<Varto_Platform> _spawnedPlatforms;
        private float _lastPlatformSpawnedOnPosition;

        private void Awake()
        {
            _spawnedPlatforms = new List<Varto_Platform>();
            _lastPlatformSpawnedOnPosition = _target.position.y;

            _spawnPattern.Init(_target, transform, _bounds);
            SpawnPlatform();
        }

        private void Update()
        {
            if (IsCanSpawnPlatforms())
            {
                SpawnPlatform();
            }

            for (int i = _spawnedPlatforms.Count - 1; i >= 0; i--)
            {
                var platform = _spawnedPlatforms[i];

                if (platform.transform.position.y < _target.position.y - _destroyOffset)
                {
                    _spawnedPlatforms.Remove(platform);
                    Destroy(platform.gameObject);
                }
            }
        }

        private bool IsCanSpawnPlatforms()
        {
            return _target != null && _target.position.y > _lastPlatformSpawnedOnPosition - _spawnOffset;
        }

        private void SpawnPlatform()
        {
            _lastPlatformSpawnedOnPosition += _groupStepHeight;
            var result = _spawnPattern.SpawnNextGroup(_lastPlatformSpawnedOnPosition);

            _spawnedPlatforms.AddRange(result.SpawnedPlatforms);
            _lastPlatformSpawnedOnPosition = result.LastSpawnedHeight;
        }
    }
}
