using UnityEngine;
using System.Collections.Generic;

namespace Examples.Player
{
    public abstract class PlatformGeneratorBase : MonoBehaviour
    {
        protected List<GameObject> SpawnedPlatforms { get; set; }

        protected virtual void Awake()
        {
            SpawnedPlatforms = new List<GameObject>();
            InitGenerator();
        }

        protected abstract void InitGenerator();
        protected abstract bool IsCanSpawnPlatforms();
        protected abstract void SpawnPlatforms();
        protected abstract void DeletePlatforms();
        protected abstract void SpawnPlatform(float stepsCount);
        protected abstract bool IsCanDeletePlatforms();

        protected virtual void Update()
        {
            if (IsCanSpawnPlatforms())
            {
                SpawnPlatforms();
            }
            if (IsCanDeletePlatforms())
            {
                DeletePlatforms();
            }
        }
    }
}