using OIMOD.Core.Component;
using UnityEngine;
using Random = UnityEngine.Random;

namespace OIMOD.Core.GameMech
{
    public class OI_PlatformGenerator : MonoBehaviour
    {
        [SerializeField] private OI_GameData gameData;
        [SerializeField] private GameObject[] _platformType;
        [SerializeField] private int _spawnCount;
        [SerializeField] private float _spawnDistance;

        
        private bool _canSpawn;
        private float _distanceFromPlayerToSpawner;

        private float spawnRangeY;
        private int spawnOnLineCount;
        private int platformID;

        private void Start() => CreatePlatform();
        private void Update() 
        {
            CountDistancePlayerToSpawner();
            if (_canSpawn) CreatePlatform();
        }
        private void CountDistancePlayerToSpawner() 
        {
            var playerPosY = gameData.playerFloorTarget.transform.position.y;
            var spawnerPosY = gameData.spawnPosition.position.y;
            _distanceFromPlayerToSpawner = playerPosY - spawnerPosY;

            if ((playerPosY <= spawnerPosY) && !(_distanceFromPlayerToSpawner <= ((_spawnDistance * _spawnCount) * -1)))
            {
                _canSpawn = true;
            }
            else
            {
                _canSpawn = false;
            }
        }
        private void CreatePlatform() 
        {
            var playerHight = gameData.playerFloorTarget.transform.position.y;
            var platformTypeID = _platformType[platformID].GetComponentInChildren<OI_PlatformCore>();

            for (int i = 0; i < _spawnCount; i++) 
            {
                //TODO зробити алгоритм для підняття складності
                //алгооритм для відсоткового шансу спавну якоїсь конкретної платформи
                spawnRangeY = Random.Range(-2f, -1f);
                spawnOnLineCount = Random.Range(0, 2);
                platformID = Random.Range(0, _platformType.Length);

                switch (platformID)
                {
                    case 0:
                        platformTypeID = _platformType[platformID].GetComponentInChildren<OI_PlatformSimple>();
                        break;
                    case 1:
                        platformTypeID = _platformType[platformID].GetComponentInChildren<OI_PlatformHighJump>();
                        break;
                    case 2:
                        platformTypeID = _platformType[platformID].GetComponentInChildren<OI_PlatformShort>();
                        break;
                }


                var borderLeftPos = gameData.levelBorderLeft.transform.position;
                var borderRightPos = gameData.levelBorderRight.transform.position;

                var spawnerPosition = gameData.spawnPosition.transform.position;
                var spawnParent = gameData.spawnPlaceholder.transform;

                var spawnPosX = Random.Range(borderLeftPos.x+0.5f, borderRightPos.x-0.5f);
                var spawnPosY = _spawnDistance + spawnRangeY + spawnerPosition.y;
                var spawnPos = new Vector3(spawnPosX, spawnPosY, 0f);
                gameData.spawnPosition.transform.position = spawnPos;

                if (spawnOnLineCount > 0) 
                {
                    for (int j = 0; j < spawnOnLineCount; j++) 
                    {
                        spawnPosX = spawnPosX+(Random.Range(-3, 3));
                        var spawnedAddPlatform = Instantiate(platformTypeID, new Vector3(spawnPosX, spawnPos.y, spawnPos.z), Quaternion.identity, spawnParent);
                        spawnedAddPlatform.Init(gameData);
                    }
                }
                var spawnedPlatform = Instantiate(platformTypeID, spawnPos, Quaternion.identity, spawnParent);
                spawnedPlatform.Init(gameData);
            }
        }
    }
}

