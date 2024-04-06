using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PVitaliy.Platform
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private PlatformFactory factory;
        [Space]
        [SerializeField] private GameController gameController;
        [SerializeField] private Transform container;
        [SerializeField] private Vector2 startPlatformPosition;
        [SerializeField] private PlatformBase startingPlatform;
        [Header("Action Points")]
        [SerializeField] private Transform removeAtPoint;
        [SerializeField] private Transform collisionStartTarget;
        [SerializeField] private Transform movingPlatformsBoundsLeft;
        [SerializeField] private Transform movingPlatformsBoundsRight;
        [Header("Generation Limits Min-Max")]
        [SerializeField] private Vector2 verticalDistance;
        [SerializeField] private Vector2 horizontalDistance;
        [SerializeField] [Min(2)] private int maxPlatformCount = 8;
        [Space]
        [SerializeField] private bool drawGizmos; // Знаю що можна вимкнути в редакторі, просто щоб не забивало інші гізмозм коли показуються
        private Queue<PlatformBase> _platformQueue;
        private Vector3 _lastPlacedPlatformPosition;

        public Transform CollisionStartTarget => collisionStartTarget;
        public Transform MovingPlatformsBoundsLeft => movingPlatformsBoundsLeft;
        public Transform MovingPlatformsBoundsRight => movingPlatformsBoundsRight;

        public void Init()
        {
            _platformQueue = new Queue<PlatformBase>(maxPlatformCount);
            SpawnPlatformAt(startingPlatform, startPlatformPosition);
            for (int i = 0; i < maxPlatformCount - 1; i++)
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
            SpawnPlatformAt(platform, position);
        }

        private void SpawnPlatformAt(PlatformBase platform, Vector2 position)
        {
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
            var distance = Random.Range(verticalDistance.x, verticalDistance.y);
            var x = Random.Range(horizontalDistance.x, horizontalDistance.y);
            return new Vector2(x, _lastPlacedPlatformPosition.y + distance);
        }

        private void OnDrawGizmos()
        {
            if (!drawGizmos) return;
            // Точка спавну стартової платформи
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(startPlatformPosition, .1f);
            
            Gizmos.color = Color.red;
            var transformPosition = transform.position;
            // Горизонтальні ліміти генерації платформ
            Gizmos.DrawLine(new Vector3(horizontalDistance.x, verticalDistance.x) + transformPosition,
                new Vector3(horizontalDistance.y, verticalDistance.x) + transformPosition);
            
            // Вертикальні ліміти генерації платформ
            var avgX = (horizontalDistance.x + horizontalDistance.y) / 2;
            Gizmos.DrawLine(new Vector3(avgX, verticalDistance.x) + transformPosition, new Vector3(avgX, verticalDistance.y) + transformPosition);
        }
    }
}
