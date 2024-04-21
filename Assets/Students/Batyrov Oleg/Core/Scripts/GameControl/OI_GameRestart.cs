using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_GameRestart : MonoBehaviour
    {
        [SerializeField] private OI_GameData gameData;
        [SerializeField] private GameObject playerInstance, startPlatform, platformSpawner, cameraInstance;
        [SerializeField] private GameObject restartPlatform, platformParent, collectableParent, levelBorders;
        [SerializeField] private OI_PlatformGenerator platformGenerator;
        private Vector3 playerStartPos, platformStartPos, platformSpawnerStartPos, cameraStartPos, levelBordersStartPos;

        private void Awake()
        {
            playerStartPos = playerInstance.transform.position;
            platformStartPos = startPlatform.transform.position;
            platformSpawnerStartPos = platformSpawner.transform.position;
            cameraStartPos = cameraInstance.transform.position;
            levelBordersStartPos = levelBorders.transform.position;

            gameObject.SetActive(false);
        }
        public void OnEnable()
        {
            gameData.gameScore = 0;
            gameData.hightScore = 0;
            gameData.bonusScore = 0;
            gameData.playerIsAlive = true;

            foreach (Transform child in platformParent.transform) Destroy(child.gameObject);
            foreach (Transform child in collectableParent.transform) Destroy(child.gameObject);

            Instantiate(restartPlatform, platformStartPos, Quaternion.identity, platformParent.transform).GetComponent<OI_PlatformCore>().Init(gameData);
            ResetGenerator();

            playerInstance.transform.position = playerStartPos;
            platformSpawner.transform.position = platformSpawnerStartPos;
            cameraInstance.transform.position = cameraStartPos;
            levelBorders.transform.position = levelBordersStartPos;

            gameObject.SetActive(false);
        }
        private void ResetGenerator()
        {
            platformGenerator.beforeRandomGeneration = true;
            platformGenerator.introDifficultyLevel = 0;
            platformGenerator.randomDifficultyLevel = 1;
            platformGenerator._currentDifficultyStep = platformGenerator.difficultyStep;

            platformGenerator.spawnRateDifficultyLevel = 0;
            platformGenerator.spawnStepDifficultyLevel = 0;

            platformGenerator.firstTimeIntro = true;
            platformGenerator.firstTimeRandom = false;
        }
    }
}

