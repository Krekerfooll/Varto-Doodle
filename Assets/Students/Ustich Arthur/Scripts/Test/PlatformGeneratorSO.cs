using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class PlatformGeneratorSO : MonoBehaviour
    {
        [SerializeField] private PlatformData[] platform;
        [SerializeField] private Vector2[] _position;
        [SerializeField] private GameObject _target;

        [SerializeField] private List<GameObject> gameObjects = new List<GameObject>();

        private void Start()
        {
            for (int i = 0; i < platform.Length; i++)
            {
                gameObjects.Add(platform[i].SpawnPlatform(_target, _position[i], this.transform));
            }
        }
    }
}