using System.Collections.Generic;
using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Platforms
{
    public abstract class InitGenerator : MonoBehaviour
    {
        public List<Platform> SpawnedPlatforms { get; protected set; }

        private void Awake()
        {
            SpawnedPlatforms = new List<Platform>();
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
