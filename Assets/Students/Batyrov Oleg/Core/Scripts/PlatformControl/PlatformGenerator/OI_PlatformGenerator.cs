using OIMOD.Core.Component;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace OIMOD.Core.GameMech
{
    public class OI_PlatformGenerator : MonoBehaviour
    {
        [SerializeField] protected OI_GameData gameData;
        [SerializeField] protected List<OI_PlatformData> PlatformData;
        [SerializeField] protected int _spawnCount;

        [SerializeField] protected int difficultyStep;
        protected int difficultyLevel = 1;
        protected int _currentDifficultyStep;
        protected int _currentDifficultyLevel;

        protected float maxSpawnPositionY = 3.2f;
        protected bool _canSpawn;
        protected int spawnOnLineCount;
        protected int platformID;
        protected OI_PlatformCore platformType;
        protected Transform spawnParent;

        private bool CanSpawn
        {
            get
            {
                var playerPosY = gameData.playerFloorTarget.transform.position.y;
                var spawnerPosY = gameData.spawnPosition.position.y;
                var _distanceFromPlayerToSpawner = playerPosY - spawnerPosY;

                if ((playerPosY <= spawnerPosY) && !(_distanceFromPlayerToSpawner <= ((maxSpawnPositionY * _spawnCount) * -1)))
                    _canSpawn = true;
                else _canSpawn = false;
                return _canSpawn;
            }
        }
        private void Awake()
        {
            spawnParent = gameData.spawnPlaceholder.transform;
            PlatformDataValueRefresh();
            _currentDifficultyStep = difficultyStep;
        }
        private void Start() => SpawnPlatform();
        private void Update() 
        {
            if (CanSpawn) SpawnPlatform();
            CheckDifficulty();
        }
        private void SpawnPlatform() 
        {
            var playerHight = gameData.playerFloorTarget.transform.position.y;
            for (int i = 0; i < _spawnCount; i++) 
            {
                _currentDifficultyStep--;
                GetPlatformToSpawn();

                spawnOnLineCount = Random.Range(0, 2);

                if (spawnOnLineCount > 0) 
                {
                    for (int j = 0; j < spawnOnLineCount; j++) 
                    {
                        var spawnPosOnLine = PlatformSpawnPosition(true);
                        gameData.spawnPosition.transform.position = spawnPosOnLine;
                        var spawnedAddPlatform = Instantiate(platformType, spawnPosOnLine, Quaternion.identity, spawnParent);
                        spawnedAddPlatform.Init(gameData);
                    }
                }
                var spawnPos = PlatformSpawnPosition(false);
                gameData.spawnPosition.transform.position = spawnPos;
                var spawnedPlatform = Instantiate(platformType, spawnPos, Quaternion.identity, spawnParent);
                spawnedPlatform.Init(gameData);
            }
        }
        private void GetPlatformToSpawn()
        {
            for (int i = PlatformData.Count - 1; i >= 0; i--)
            {
                var platform = PlatformData[i];
                int spawnChance = Random.Range(0, MaxRandomSpawnRateValue());

                platform.currentStep--;

                if ((platform.spawnRate > 0) && (platform.currentStep == 0) && (platform.spawnRate >= spawnChance))
                {
                    platform.currentStep = platform.stepsToSpawn;
                    platformID = i;
                    break;
                }
            }
            PlatformDataValueRefresh();
            platformType = PlatformData[platformID].platformPrefab.GetComponent<OI_PlatformCore>();
        }
        private void PlatformDataValueRefresh()
        {
            for (int i = PlatformData.Count - 1; i >= 0; i--)
            {
                var platform = PlatformData[i];

                if (platform.spawnRate <= 0) platform.spawnRate = 0;
                if (platform.stepsToSpawn <= 0) platform.stepsToSpawn = 0;
                if (platform.currentStep <= 0) platform.currentStep = platform.stepsToSpawn;
            }
        }
        private int MaxRandomSpawnRateValue()
        {
            int maxRandomValue = 0;

            for (int i = PlatformData.Count - 1; i >= 0; i--)
            {
                int currentValue = PlatformData[i].spawnRate;
                if (currentValue > maxRandomValue)
                {
                    maxRandomValue = currentValue;
                }
            }
            return maxRandomValue;
        }

        private Vector3 PlatformSpawnPosition(bool oneLine)
        {
            Vector3 spawnPos;
            Vector3 spawnerPosition = gameData.spawnPosition.transform.position;

            float borderLeftPos = gameData.levelBorderLeft.transform.position.x + 0.8f;
            float borderRightPos = gameData.levelBorderRight.transform.position.x - 0.8f;

            float spawnVariationY = Mathf.Lerp(1f, maxSpawnPositionY, difficultyLevel / 10f);

            float posX = 0;
            float posY;

            if (oneLine)
            {
                if (spawnerPosition.x < 0)
                    posX = Random.Range(0.5f, borderRightPos);
                else if (spawnerPosition.x >= 0)
                    posX = Random.Range(-0.5f, borderLeftPos);
                posY = spawnerPosition.y;
            }
            else
            {
                posX = Random.Range(borderLeftPos, borderRightPos);
                posY = spawnVariationY + spawnerPosition.y;
            }

            posX = Mathf.Clamp(posX, borderLeftPos, borderRightPos);
            spawnPos = new Vector3 (posX, posY, 0f);
            return spawnPos;
        }
        public void CheckDifficulty()
        {
            if (_currentDifficultyStep <= 0)
            {
                _currentDifficultyStep = difficultyStep;
                difficultyLevel++;
                _currentDifficultyLevel++;
            }
            if (_currentDifficultyLevel >= 5)
            {
                _currentDifficultyLevel = 0;
                for (int i = PlatformData.Count - 1; i >= 0; i--)
                {
                    var platform = PlatformData[i];

                    if (!platform.isDeadly && !platform.isSpecial)
                    {
                        platform.spawnRate = Random.Range(50, 100);
                        platform.stepsToSpawn = Random.Range(0, 10);
                    }
                    else if (!platform.isDeadly && platform.isSpecial)
                    {
                        platform.spawnRate = Random.Range(0, 70);
                        platform.stepsToSpawn = Random.Range(3, 11);
                    }
                    else if (!platform.isDeadly && platform.isSpecial)
                    {
                        platform.spawnRate = Random.Range(0, 50);
                        platform.stepsToSpawn = Random.Range(2, 11);
                    }
                    else if (platform.isDeadly && platform.isSpecial)
                    {
                        platform.spawnRate = Random.Range(0, 25);
                        platform.stepsToSpawn = Random.Range(7, 11);
                    }
                }
            }
        }
    }
}

