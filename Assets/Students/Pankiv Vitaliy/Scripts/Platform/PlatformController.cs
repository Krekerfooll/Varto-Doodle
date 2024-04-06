using System.Collections.Generic;
using UnityEngine;

namespace PVitaliy.Platform
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private PlatformFactory factory;
        [SerializeField] private GameController gameController;
        [SerializeField] private Transform container;
        [SerializeField] private Vector2 distanceLimits;
        [SerializeField] private Vector2 horizontalPositionLimits;
        private Queue<PlatformBase> _platformQueue;
        private Vector3 _lastPlatformPosition;

        public void SpawnPlatformAt(PlatformType type, Vector2 position)
        {
            var platform = factory.CreatePlatform(type, this);
            var instance = Instantiate(platform, position, Quaternion.identity, container);
            _lastPlatformPosition = instance.transform.position;
        }
        
        private Vector2 NewPlatformPosition
        {
            get
            {
                var distance = Random.Range(distanceLimits.x, distanceLimits.y);
                var x = Random.Range(horizontalPositionLimits.x, horizontalPositionLimits.y);
                return new Vector2(x, _lastPlatformPosition.y + distance);
            }
        }
    }
}
