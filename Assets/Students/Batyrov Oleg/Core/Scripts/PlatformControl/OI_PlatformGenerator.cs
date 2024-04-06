using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace OIMOD.Core.GameMech
{
    public class OI_PlatformGenerator : MonoBehaviour
    {
        [Header("Platforms List")]
        [Space]
        [SerializeField] private GameObject[] _platformType;
        [SerializeField] private GameObject ColorManager;
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


        private void Start() {
            CreatePlatform();
        }
        private void Update() {
            CountDistance();
            if (_canSpawn)
                CreatePlatform();
        }
        private void CountDistance() {
            var playerPos = _playerTarget.position.y;
            var targetPos = _spawnTarget.position.y;
            _distanceFromPlayerToSpawner = playerPos - targetPos;

            if ((playerPos <= targetPos) && !(_distanceFromPlayerToSpawner <= ((_spawnDistance*_spawnDistance)*-1)))
                _canSpawn = true;
            else 
                _canSpawn = false;
        }
        private void CreatePlatform() {
            var playerHight = _playerTarget.position.y;
            var platformTypeID = _platformType[platformID].GetComponent<OI_PlatformCore>();
            var colorChangeList = ColorManager.GetComponent<OI_ColorManager>().layerToChangeColor;

            for (int i = 0; i < _spawnCount; i++) {

                if (playerHight is >= 0 and < 25)  {
                    spawnRangeY = Random.Range(-2f, -1f);
                    spawnOnLineCount = Random.Range(1, 2);
                    platformID = 0;
                }
                else if (playerHight is >= 25 and < 50) {
                    spawnRangeY = Random.Range(-2f, 0f);
                    spawnOnLineCount = Random.Range(0, 1);
                    platformID = Random.Range(0, 2);
                }
                else if (playerHight is >= 50 and < 100) {
                    spawnRangeY = Random.Range(-1f, 0f);
                    spawnOnLineCount = Random.Range(0, 1);
                    platformID = Random.Range(0, 3);
                }
                else if (playerHight is >= 100 and < 150) {
                    spawnRangeY = Random.Range(0.5f, 0f);
                    spawnOnLineCount = 0;
                    platformID = Random.Range(1, 3);
                }
                else if (playerHight is >= 150 and < 200) {
                    spawnRangeY = Random.Range(0.5f, 0f);
                    spawnOnLineCount = 0;
                    platformID = Random.Range(2, 3);
                }
                else if (playerHight is >= 200 and < 1000)
                {
                    spawnRangeY = Random.Range(0.5f, 0f);
                    spawnOnLineCount = 0;
                    platformID = Random.Range(0, 3);
                }
                switch (platformID) {
                    case 0:
                        platformTypeID = _platformType[platformID].GetComponent<OI_PlatformSimple>();
                        break;
                    case 1:
                        platformTypeID = _platformType[platformID].GetComponent<OI_PlatformHighJump>();
                        break;
                    case 2:
                        platformTypeID = _platformType[platformID].GetComponent<OI_PlatformShort>();
                        break;
                }

                var spawnPosX = Random.Range(_borderLeft.position.x+0.5f, _borderRight.position.x-0.5f);
                var spawnPosY = _spawnDistance + spawnRangeY + _spawnTarget.position.y;
                var spawnPos = new Vector3(spawnPosX, spawnPosY, 0f);
                _spawnTarget.position = spawnPos;

                if (spawnOnLineCount > 0) {
                    for (int j = 0; j < spawnOnLineCount; j++) {
                        spawnPosX = spawnPosX+(Random.Range(-3, 3));
                        var spawnedAddPlatform = Instantiate(platformTypeID, new Vector3(spawnPosX, spawnPos.y, spawnPos.z), Quaternion.identity, _spawnParent);
                        spawnedAddPlatform.Init(_playerTarget, _destroyBorder, _playerRb, _playerJumpForce, _jumpMultiplier);
                        colorChangeList.Add(spawnedAddPlatform.GetComponentInChildren<SpriteRenderer>());
                    }
                }
                var spawnedPlatform = Instantiate(platformTypeID, spawnPos, Quaternion.identity, _spawnParent);
                spawnedPlatform.Init(_playerTarget, _destroyBorder, _playerRb, _playerJumpForce, _jumpMultiplier);
                colorChangeList.Add(spawnedPlatform.GetComponentInChildren<SpriteRenderer>());
            }
        }
    }
}

