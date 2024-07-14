using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Varto.Examples.Platforms;

namespace Alokhin.Stanislav.Platforms
{
    public abstract class PlatformGeneratorBase : MonoBehaviour
    {
        public List<Platforms> SpawnedPlatforms { get; protected set; }

        private void Awake()
        {
            SpawnedPlatforms = new List<Platforms>();
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

