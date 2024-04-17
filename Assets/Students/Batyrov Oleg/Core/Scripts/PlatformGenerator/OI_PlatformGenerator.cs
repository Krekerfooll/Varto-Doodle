using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace OIMOD.Core.Component
{
    public class OI_PlatformGenerator : MonoBehaviour
    {
        [SerializeField] protected OI_GameData gameData;
        [SerializeField] protected List<OI_PlatformData> PlatformData;
        [SerializeField] protected int _spawnCount;

        [SerializeField] protected int difficultyStep;
        [SerializeField][Range(1,10)] protected int difficultyLevelStep;
        protected bool beforeRandomGeneration;
        protected int introDifficultyLevel = 1;
        protected int randomDifficultyLevel = 1;
        protected int _currentDifficultyStep;
        protected int _currentDifficultyLevel;

        protected int gameDifficultyLevel = 0;
        protected int maxDifficultyLevel = 9;

        protected bool firstTimeIntro;
        protected bool firstTimeRandom;

        protected bool hasSpawnedOnLine;

        protected bool _canSpawn;
        protected float maxSpawnPositionY = 3.2f;
        protected int hightDifficulty = 1;

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
            firstTimeIntro = true;
            firstTimeRandom = false;
            beforeRandomGeneration = true;
            spawnParent = gameData.spawnPlaceholder.transform;
            _currentDifficultyStep = difficultyStep;
            PlatformDataValueRefresh();
        }
        private void Start() 
        {
            SpawnPlatform();
        } 
        private void Update() 
        {
            if (gameData.playerInstance != null && CanSpawn) SpawnPlatform();
        }
        private void SpawnPlatform() 
        {

            int random = Random.Range(0, 10);
            bool alowSpawnOlLine = random > 5  ? true: false;
            bool canSpawnOnLine = alowSpawnOlLine && !hasSpawnedOnLine ? true : false;

            for (int i = 0; i < _spawnCount; i++) 
            {
                ManageDifficulty();
                GetPlatformToSpawn();

                if (!canSpawnOnLine)
                {
                    hasSpawnedOnLine = false;

                    var spawnPos = PlatformSpawnPosition(false);
                    gameData.spawnPosition.transform.position = spawnPos;
                    var spawnedPlatform = Instantiate(platformType, spawnPos, Quaternion.identity, spawnParent);
                    spawnedPlatform.Init(gameData);
                }
                else if (canSpawnOnLine && !hasSpawnedOnLine) 
                {
                    hasSpawnedOnLine = true;
                    for (int j = 0; j < 1; j++) 
                    {
                        var spawnPosOnLine = PlatformSpawnPosition(true);
                        gameData.spawnPosition.transform.position = spawnPosOnLine;
                        var spawnedAddPlatform = Instantiate(platformType, spawnPosOnLine, Quaternion.identity, spawnParent);
                        spawnedAddPlatform.Init(gameData);
                    }
                }
            }
        }
        private void GetPlatformToSpawn()
        {
            PlatformDataValueRefresh();
            

            for (int i = PlatformData.Count - 1; i >= 0; i--)
            {
                var platform = PlatformData[i];
                int spawnChance = Random.Range(0, MaxRandomSpawnRateValue());

                if (platform.currentStep > 0) platform.currentStep--;

                if ((platform.spawnRate > 0) && (platform.currentStep == 0) && (platform.spawnRate >= spawnChance))
                {
                    platform.currentStep = platform.stepsToSpawn;
                    platformID = i;
                    break;
                }
            }
            platformType = PlatformData[platformID].platformPrefab.GetComponent<OI_PlatformCore>();
        }
        private void PlatformDataValueRefresh()
        {
            for (int i = PlatformData.Count - 1; i >= 0; i--)
            {
                var platform = PlatformData[i];

                if (platform.spawnRate < 0) platform.spawnRate = 0;
                if (platform.stepsToSpawn < 0) platform.stepsToSpawn = 0;
                if (platform.currentStep < 0) platform.currentStep = platform.stepsToSpawn;
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

            float spawnVariationY = Mathf.Lerp(1f, maxSpawnPositionY, hightDifficulty / 10f);

            float posX = 0;
            float posY;

            if (oneLine)
            {
                if (spawnerPosition.x < 0)
                    posX = Random.Range(0.7f, borderRightPos);
                else if (spawnerPosition.x >= 0)
                    posX = Random.Range(-0.7f, borderLeftPos);
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
        public void ManageDifficulty()
        {
            _currentDifficultyStep--;
            bool readyToChangeRates = false;

            if (beforeRandomGeneration)
            {
                if (_currentDifficultyStep == 0)
                {
                    introDifficultyLevel++;
                    readyToChangeRates = true;
                }
                _currentDifficultyStep = _currentDifficultyStep <= 0 ? difficultyStep : _currentDifficultyStep;

                if (introDifficultyLevel == 1 && readyToChangeRates)
                {
                    int[] simpleSpawnData = { 100, 100, 1, 1 };
                    int[] smallSpawnData = { 10, 15, 10, 10 };
                    int[] highJumpSpawnData = { 30, 50, 3, 5 };
                    int[] simpleBrokenSpawnData = { 0, 0, 0, 0 };
                    int[] smallBrokenSpawnData = { 0, 0, 0, 0 };
                    int[] deadlySpawnData = { 0, 0, 0, 0 };
                    hightDifficulty = 3;

                    GeneratePlatformRates(simpleSpawnData, smallSpawnData, highJumpSpawnData, 
                        simpleBrokenSpawnData, smallBrokenSpawnData, deadlySpawnData);
                }
                else if (introDifficultyLevel == 2 && readyToChangeRates)
                {
                    int[] simpleSpawnData = { 0, 0, 0, 0 };
                    int[] smallSpawnData = { 100, 100, 1, 1 };
                    int[] highJumpSpawnData = { 30, 50, 3, 5 };
                    int[] simpleBrokenSpawnData = { 0, 0, 0, 0 };
                    int[] smallBrokenSpawnData = { 0, 0, 0, 0 };
                    int[] deadlySpawnData = { 0, 0, 0, 0 };
                    hightDifficulty = 5;

                    GeneratePlatformRates(simpleSpawnData, smallSpawnData, highJumpSpawnData,
                        simpleBrokenSpawnData, smallBrokenSpawnData, deadlySpawnData);
                }
                else if (introDifficultyLevel == 3 && readyToChangeRates)
                {
                    int[] simpleSpawnData = { 0, 0, 0, 0 };
                    int[] smallSpawnData = { 0, 0, 0, 0 };
                    int[] highJumpSpawnData = { 30, 50, 3, 5 };
                    int[] simpleBrokenSpawnData = { 100, 100, 1, 1 };
                    int[] smallBrokenSpawnData = { 10, 15, 10, 10 };
                    int[] deadlySpawnData = { 0, 0, 0, 0 };
                    hightDifficulty = 2;

                    GeneratePlatformRates(simpleSpawnData, smallSpawnData, highJumpSpawnData,
                        simpleBrokenSpawnData, smallBrokenSpawnData, deadlySpawnData);
                }
                else if (introDifficultyLevel == 4 && readyToChangeRates)
                {
                    int[] simpleSpawnData = { 0, 0, 0, 0 };
                    int[] smallSpawnData = { 0, 0, 0, 0 };
                    int[] highJumpSpawnData = { 30, 50, 3, 5 };
                    int[] simpleBrokenSpawnData = { 0, 0, 0, 0 };
                    int[] smallBrokenSpawnData = { 100, 100, 1, 1 };
                    int[] deadlySpawnData = { 0, 0, 0, 0 };
                    hightDifficulty = 5;

                    GeneratePlatformRates(simpleSpawnData, smallSpawnData, highJumpSpawnData,
                        simpleBrokenSpawnData, smallBrokenSpawnData, deadlySpawnData);
                }
                else if (introDifficultyLevel == 5 && readyToChangeRates)
                {
                    int[] simpleSpawnData = { 100, 100, 1, 1 };
                    int[] smallSpawnData = { 50, 80, 3, 3 };
                    int[] highJumpSpawnData = { 30, 50, 3, 5 };
                    int[] simpleBrokenSpawnData = { 0, 0, 0, 0 };
                    int[] smallBrokenSpawnData = { 0, 0, 0, 0 };
                    int[] deadlySpawnData = { 50, 50, 4, 5 };
                    hightDifficulty = 7;

                    GeneratePlatformRates(simpleSpawnData, smallSpawnData, highJumpSpawnData,
                        simpleBrokenSpawnData, smallBrokenSpawnData, deadlySpawnData);
                }
                else if (introDifficultyLevel == 6)
                {
                    beforeRandomGeneration = false;
                    firstTimeRandom = true;
                }
            }
            if (!beforeRandomGeneration)
            {
                randomDifficultyLevel = _currentDifficultyStep == 0 ? randomDifficultyLevel++ : randomDifficultyLevel;
                _currentDifficultyStep = _currentDifficultyStep <= 0 ? difficultyStep : _currentDifficultyStep;
                hightDifficulty = gameDifficultyLevel;

                if (randomDifficultyLevel > difficultyLevelStep || firstTimeRandom)
                {
                    gameDifficultyLevel = gameDifficultyLevel == maxDifficultyLevel ? maxDifficultyLevel : gameDifficultyLevel++;
                    randomDifficultyLevel = 1;

                    int[] simpleSpawnData = { 1, 100 - gameDifficultyLevel, 1, 1 + gameDifficultyLevel };
                    int[] smallSpawnData = { 1, 30 - gameDifficultyLevel, 1, 1 + gameDifficultyLevel };
                    int[] highJumpSpawnData = { 35, 50 + gameDifficultyLevel, 5, 10 - gameDifficultyLevel };
                    int[] simpleBrokenSpawnData = { 1, 50 + gameDifficultyLevel, 5, 10 - gameDifficultyLevel };
                    int[] smallBrokenSpawnData = { 1, 50 + gameDifficultyLevel, 5, 10 - gameDifficultyLevel };
                    int[] deadlySpawnData = { 1, 10 + gameDifficultyLevel, 10, 10 - gameDifficultyLevel };

                    GeneratePlatformRates(simpleSpawnData, smallSpawnData, highJumpSpawnData,
                        simpleBrokenSpawnData, smallBrokenSpawnData, deadlySpawnData);
                    firstTimeRandom = false;
                }
            }
        }
        public void GeneratePlatformRates(int[] simple, int[] small, int[] highJump,
            int[] simpleBroken,int[] smallBroken, int[] deadly)
        {
            int[] simpleSpawnData = simple;
            int[] smallSpawnData = small;
            int[] highJumpSpawnData = highJump;
            int[] simpleBrokenSpawnData = simpleBroken;
            int[] smallBrokenSpawnData = smallBroken;
            int[] deadlySpawnData = deadly;

            for (int i = PlatformData.Count - 1; i >= 0; i--)
            {
                var platform = PlatformData[i];

                if (platform.isSimple)
                {
                    platform.spawnRate = Random.Range(simpleSpawnData[0], simpleSpawnData[1]);
                    platform.stepsToSpawn = Random.Range(simpleSpawnData[2], simpleSpawnData[3]);
                }
                else if (platform.isSmall)
                {
                    platform.spawnRate = Random.Range(smallSpawnData[0], smallSpawnData[1]);
                    platform.stepsToSpawn = Random.Range(smallSpawnData[2], smallSpawnData[3]);
                }
                else if (platform.isHighJump)
                {
                    platform.spawnRate = Random.Range(highJumpSpawnData[0], highJumpSpawnData[1]);
                    platform.stepsToSpawn = Random.Range(highJumpSpawnData[2], highJumpSpawnData[3]);
                }
                else if (platform.isSimpleBroken)
                {
                    platform.spawnRate = Random.Range(simpleBrokenSpawnData[0], simpleBrokenSpawnData[1]);
                    platform.stepsToSpawn = Random.Range(simpleBrokenSpawnData[2], simpleBrokenSpawnData[3]);
                }
                else if (platform.isSmallBroken)
                {
                    platform.spawnRate = Random.Range(smallBrokenSpawnData[0], smallBrokenSpawnData[1]);
                    platform.stepsToSpawn = Random.Range(smallBrokenSpawnData[2], smallBrokenSpawnData[3]);
                }
                else if (platform.isDeadly)
                {
                    platform.spawnRate = Random.Range(deadlySpawnData[0], deadlySpawnData[1]);
                    platform.stepsToSpawn = Random.Range(deadlySpawnData[2], deadlySpawnData[3]);
                }
            }
        }
    }
}

