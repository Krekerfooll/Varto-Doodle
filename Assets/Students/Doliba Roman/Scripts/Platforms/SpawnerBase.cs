using System.Collections.Generic;
using UnityEngine;

namespace RomanDoliba.Platform
{
    public abstract class SpawnerBase : MonoBehaviour
    {
        public List<Platform> PlatformsTypes { get; protected set; }
        private void Awake()
        {
            PlatformsTypes = new List<Platform>();
            SpawnOnAwake();
        }

        private void Update()
        {
            if (CanSpawnPlatforms())
            {
                SpawnPlatforms();
            }
            else if (CanDeletePlatforms())
            {
                DeletePlatforms();
            }
        }

        protected abstract bool CanSpawnPlatforms();
        protected abstract bool CanDeletePlatforms();
        
        protected abstract void SpawnOnAwake();
        protected abstract void SpawnPlatforms();
        protected abstract void DeletePlatforms();
    }
}
