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
        [Header("Action Points")]
        [SerializeField] private Transform removeAtPoint;
        [SerializeField] private Transform collisionStartTarget;
        [SerializeField] private Transform movingPlatformsBoundsLeft;
        [SerializeField] private Transform movingPlatformsBoundsRight;
        [Space]
        [SerializeField] private bool drawGizmos; // Знаю що можна вимкнути в редакторі, просто щоб не забивало інші гізмозм коли показуються
        private Queue<PlatformBase> _platformQueue;
        private Vector3 _lastPlacedPlatformPosition;

        public Transform CollisionStartTarget => collisionStartTarget;
        public Transform MovingPlatformsBoundsLeft => movingPlatformsBoundsLeft;
        public Transform MovingPlatformsBoundsRight => movingPlatformsBoundsRight;

        public void Init()
        {
            _platformQueue = new Queue<PlatformBase>(factory.maxPlatformCount);
            SpawnPlatformAt(factory.startingPlatform, startPlatformPosition);
            for (int i = 0; i < factory.maxPlatformCount - 1; i++)
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
            var distance = Random.Range(factory.verticalDistance.x, factory.verticalDistance.y);
            var x = Random.Range(factory.horizontalDistance.x, factory.horizontalDistance.y);
            return new Vector2(x, _lastPlacedPlatformPosition.y + distance);
        }

        private void OnDrawGizmos()
        {
            if (!drawGizmos) return;
            // Точка спавну стартової платформи
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(startPlatformPosition, .1f);
            
            Gizmos.color = Color.blue;
            var transformPosition = transform.position;
            // Горизонтальні ліміти генерації платформ
            Gizmos.DrawLine(new Vector3(factory.horizontalDistance.x, factory.verticalDistance.x) + transformPosition,
                new Vector3(factory.horizontalDistance.y, factory.verticalDistance.x) + transformPosition);
            
            // Вертикальні ліміти генерації платформ
            var avgX = (factory.horizontalDistance.x + factory.horizontalDistance.y) / 2;
            var startPoint = new Vector3(avgX, factory.verticalDistance.x) + transformPosition;
            Gizmos.DrawLine(startPoint, new Vector3(avgX, factory.verticalDistance.y) + transformPosition);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(startPoint, new Vector3(avgX, 0) + transformPosition);
        }
    }
}
