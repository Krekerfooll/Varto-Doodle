using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class GeneratorTestScriptbl : MonoBehaviour
    {
        [SerializeField] private PlatformData[] _platformData;

        private List<PlatformData.TestStruct> _testPlatformStruct = new List<PlatformData.TestStruct>();

        private void Start()
        {
            for (int i = 0; i < _platformData.Length; i++)
                _testPlatformStruct.Add(_platformData[i].SpawnPrefab());

            ChangeSprite();
        }

        private void ChangeSprite()
        {
            foreach (var _test in _testPlatformStruct)
            {
                var _GameObject = _test._gameObject;
                var _Sprite = _test._sprite;


                switch (_test._platformType)
                {
                    case PlatformType.Base:
                        break;
                    case PlatformType.Moved:
                        _GameObject.AddComponent<MovedPlatform>();
                        break;
                    case PlatformType.Brocken:
                        Debug.Log($"Platform is {_test._platformType}");
                        Destroy(_GameObject);
                        break;
                }

                _GameObject.GetComponent<SpriteRenderer>().sprite = _Sprite;
            }
        }
    }
}