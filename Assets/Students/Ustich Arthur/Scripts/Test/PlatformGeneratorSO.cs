using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class PlatformGeneratorSO : MonoBehaviour
    {
        [SerializeField] private PlatformData platform;
        [SerializeField] private Vector2 _position;
        [SerializeField] private GameObject _target;

        private void Start()
        {
            _position = new Vector2(0, 0);
            var gb = platform.SpawnPlatform(_target, _position, this.transform);
            Debug.Log(gb);
        }
    }
}