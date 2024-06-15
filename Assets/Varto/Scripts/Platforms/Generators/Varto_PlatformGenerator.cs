using System.Collections.Generic;
using UnityEngine;
using Varto.Examples.Data;

namespace Varto.Examples.Platforms
{
    public class Varto_PlatformGenerator : MonoBehaviour
    {
        [Header("Global Settings:")]
        [Space]
        [SerializeField] private Transform _target;
        [SerializeField] private PlatformsDatabase _platformsDatabase;
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

            if (!TryLoadData())
            {
                SpawnPlatform();
            }
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

            SaveData();
        }

        private bool TryLoadData()
        {
            if (PlayerPrefs.HasKey("VARTO_DOODLE_LAST_PLATFORM_SPAWNED_POSITION"))
            {
                _lastPlatformSpawnedOnPosition = PlayerPrefs.GetFloat("VARTO_DOODLE_LAST_PLATFORM_SPAWNED_POSITION");

                var loadedGeneratedPlatformsData = PlayerPrefs.GetString("VARTO_DOODLE_SPAWNED_PLATFORMS");
                var platformsDataList = JsonUtility.FromJson<PlatformsSaveDataList>(loadedGeneratedPlatformsData);

                foreach (var platformData in platformsDataList.PlatformsSaveData)
                {
                    if (_platformsDatabase.TryGetPlatform(platformData.PlatformType, out var platform))
                    {
                        var spawnedPlatform = Instantiate(platform, platformData.PlatformPosition, Quaternion.identity, transform);
                        spawnedPlatform.Init(_target, platformData.IsPlatformActivated);
                        _spawnedPlatforms.Add(spawnedPlatform);
                    }
                }

                return true;
            }

            return false;
        }
        private void SaveData()
        {
            var platformsSaveDataList = new List<PlatformSaveData>();

            for (int i = 0; i < _spawnedPlatforms.Count; i++)
            {
                var platform = _spawnedPlatforms[i];

                platformsSaveDataList.Add(
                    new PlatformSaveData(
                        platform.gameObject.name.Replace("(Clone)", ""), 
                        platform.transform.position,
                        platform.IsPlatformActivated));
            }

            var spawnedPlatforms = JsonUtility.ToJson(new PlatformsSaveDataList(platformsSaveDataList));

            PlayerPrefs.SetString("VARTO_DOODLE_SPAWNED_PLATFORMS", spawnedPlatforms);
            PlayerPrefs.SetFloat("VARTO_DOODLE_LAST_PLATFORM_SPAWNED_POSITION", _lastPlatformSpawnedOnPosition);
            PlayerPrefs.Save();
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


        [System.Serializable]
        public struct PlatformsSaveDataList
        {
            public List<PlatformSaveData> PlatformsSaveData;

            public PlatformsSaveDataList(List<PlatformSaveData> platformsSaveData)
            {
                PlatformsSaveData = platformsSaveData;
            }
        }

        [System.Serializable]
        public struct PlatformSaveData
        {
            public string PlatformType;
            public Vector3 PlatformPosition;
            public bool IsPlatformActivated;

            public PlatformSaveData(string platformType, Vector3 platformPosition, bool isPlatformActivated)
            {
                PlatformType = platformType;
                PlatformPosition = platformPosition;
                IsPlatformActivated = isPlatformActivated;
            }
        }
    }
}
