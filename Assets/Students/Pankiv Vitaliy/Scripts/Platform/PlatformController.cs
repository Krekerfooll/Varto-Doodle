using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PVitaliy.Platform
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private PlatformFactory factory;
        [SerializeField] private GameController gameController;
        [SerializeField] private Transform container;
        [SerializeField] private Transform removeAtPoint;
        [SerializeField] private Transform collisionStartTarget;
        [SerializeField] private Vector2 distanceLimits;
        [SerializeField] private Vector2 horizontalPositionLimits;
        [SerializeField] private bool drawGizmos = false;
        private Queue<PlatformBase> _platformQueue;
        private Vector3 _lastPlacedPlatformPosition;

        public Transform CollisionStartTarget => collisionStartTarget;

        public void Init(Vector2 startPosition, int maxCount)
        {
            _platformQueue = new Queue<PlatformBase>(maxCount);
            SpawnPlatformAt(PlatformType.Static, startPosition);
            for (int i = 0; i < maxCount - 1; i++)
            {
                SpawnNewPlatform();
            }
        }

        private void SpawnNewPlatform()
        {
            SpawnPlatformAt(factory.GetRandomPlatformType(), GetNewPlatformPosition());
        }

        private void SpawnPlatformAt(PlatformType type, Vector2 position)
        {
            var platform = factory.CreatePlatform(type);
            var instance = Instantiate(platform, position, Quaternion.identity, container);
            instance.Init(this);
            _lastPlacedPlatformPosition = instance.transform.position;
            _platformQueue.Enqueue(instance);
        }

        private void FixedUpdate()
        {
            var bottomPlatform = _platformQueue.Peek();
            if (!bottomPlatform || bottomPlatform.transform.position.y < removeAtPoint.position.y)
            {
                RemoveLastPlatformAndSpawnNew();
            }
        }

        private void RemoveLastPlatformAndSpawnNew()
        {
            var platform = _platformQueue.Dequeue();
            if (platform) Destroy(platform.gameObject);
            SpawnNewPlatform();
        }

        private Vector2 GetNewPlatformPosition()
        {
            var distance = Random.Range(distanceLimits.x, distanceLimits.y);
            var x = Random.Range(horizontalPositionLimits.x, horizontalPositionLimits.y);
            return new Vector2(x, _lastPlacedPlatformPosition.y + distance);
        }

        private void OnDrawGizmos()
        {
            if (!drawGizmos) return;
            Gizmos.color = Color.red;
            var transformPosition = transform.position;
            Gizmos.DrawLine( // Горизонтальні ліміти генерації платформ
                new Vector3(horizontalPositionLimits.x, distanceLimits.x) + transformPosition,
                new Vector3(horizontalPositionLimits.y, distanceLimits.x) + transformPosition);
            
            var avgX = (horizontalPositionLimits.x + horizontalPositionLimits.y) / 2;
            // Вертикальні ліміти генерації платформ
            Gizmos.DrawLine(new Vector3(avgX, distanceLimits.x) + transformPosition, new Vector3(avgX, distanceLimits.y) + transformPosition);
        }
    }
}
