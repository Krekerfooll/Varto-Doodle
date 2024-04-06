using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace OIMOD.Core.GameMech
{
    public class OI_PlatformGenerator : MonoBehaviour
    {
        [Header("Platforms List")]
        [Space]
        [SerializeField] private GameObject[] _platformType;
        [Space]
        [Header("Complex Platform Setup")]
        [Space]
        [SerializeField] private Rigidbody2D _playerRb;
        [SerializeField] private float _playerJumpForce;
        [SerializeField] private int _jumpMultiplier;
        [Space]
        [Header("Spawn Setup")]
        [Space]
        [SerializeField] private Transform _spawnTarget;
        [SerializeField] private Transform _borderLeft;
        [SerializeField] private Transform _borderRight;
        [SerializeField] private int _spawnCount;
        [SerializeField] private float _spawnDistance;
        [SerializeField] private Transform _spawnParent;
        [Space]
        [Header("Target Setup")]
        [Space]
        [SerializeField] private Transform _playerTarget;
        [SerializeField] protected Transform _destroyBorder;
        
        private bool _canSpawn;
        private float _distanceFromPlayerToSpawner;

        private float spawnRangeY;
        private int spawnOnLineCount;
        private int platformID;

        private void Start()
        {
            CreatePlatform();
            //TODO!!!!! ќ—№ “ј  ÷я ’”…Ќя Ѕ”ƒ≈ ѕ–ј÷ё¬ј“»!
            //через вар задаЇмо скрипт ≥ вручну д≥стаЇмо кожен
            //дал≥ можливо через св≥тч кейс будемо повертати значенн€ в вар
            var platformID = _platformType[0].GetComponent<OI_PlatformHighJump>();
        }
        private void Update()
        {
            CountDistance();
            if (_canSpawn)
                CreatePlatform();
        }
        private void CountDistance()
        {
            var playerPos = _playerTarget.position.y;
            var targetPos = _spawnTarget.position.y;
            _distanceFromPlayerToSpawner = playerPos - targetPos;

            if ((playerPos <= targetPos) && !(_distanceFromPlayerToSpawner <= ((_spawnDistance*_spawnDistance)*-1)))
                _canSpawn = true;
            else 
                _canSpawn = false;
        }
        private void CreatePlatform()
        {
            var playerHight = _playerTarget.position.y;
            
            if (playerHight is >= 0 and < 50)
            {
                spawnRangeY = Random.Range(-2f, -1f);
                spawnOnLineCount = Random.Range(1, 2);
                platformID = Random.Range(0, 2);
            }
            else if (playerHight is >= 50 and < 150)
            {
                spawnRangeY = Random.Range(-2f, 0f);
                spawnOnLineCount = Random.Range(0, 1);
                platformID = Random.Range(0, 2);
            }
            else if (playerHight is >= 150 and < 300)
            {
                spawnRangeY = Random.Range(-1f, 0f);
                spawnOnLineCount = Random.Range(0, 1);
            }
            else if (playerHight is >= 300 and < 500)
            {
                spawnRangeY = Random.Range(0.5f, 0f);
                spawnOnLineCount = 0;
            }


            for (int i = 0; i < _spawnCount; i++)
            {
                var spawnPosX = Random.Range(_borderLeft.position.x, _borderRight.position.x);
                var spawnPosY = _spawnDistance + spawnRangeY + _spawnTarget.position.y;
                var spawnPos = new Vector3(spawnPosX, spawnPosY, 0f);

                _spawnTarget.position = spawnPos;

                if (spawnOnLineCount > 0)
                {
                    for (int j = 0; j < spawnOnLineCount; j++)
                    {
                        spawnPosX = spawnPosX+(Random.Range(-3f, 3f));
                        var spawnedAddPlatform = Instantiate(_platformType[platformID].gameObject, new Vector3(spawnPosX, spawnPos.y, spawnPos.z), Quaternion.identity, _spawnParent);
                       // spawnedAddPlatform.Init(_playerTarget, _destroyBorder, _playerRb, _playerJumpForce, _jumpMultiplier);
                    }
                }
                var spawnedPlatform = Instantiate(_platformType[platformID].gameObject, spawnPos, Quaternion.identity, _spawnParent);
               // spawnedPlatform.Init(_playerTarget, _destroyBorder, _playerRb, _playerJumpForce, _jumpMultiplier);
            }
        }
    }
}

