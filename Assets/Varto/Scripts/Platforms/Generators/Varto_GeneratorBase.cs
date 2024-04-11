using System.Collections.Generic;
using UnityEngine;

namespace Varto.Examples.Platforms
{
    public abstract class Varto_GeneratorBase : MonoBehaviour
    {
        public List<Varto_Platform> SpawnedPlatforms { get; protected set; }

        private void Awake()
        {
            SpawnedPlatforms = new List<Varto_Platform>();
            InitGenerator();
        }

        public void Update()
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

        protected abstract void InitGenerator();

        protected abstract bool IsCanSpawnPlatforms();
        protected abstract bool IsCanDeletePlatforms();

        protected abstract void SpawnPlatforms();
        protected abstract void DeletePlatforms();
    }
}
