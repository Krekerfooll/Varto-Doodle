using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PVitaliy.Platform
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private PlatformFactory factory;
        [Space]
        [SerializeField] private Transform container;
        [SerializeField] private Vector3 startPlatformPosition;
        [Header("Action Points")]
        [SerializeField] private Transform removeAtPoint;
        [SerializeField] private Transform collisionStartTarget;
        [SerializeField] private Transform movingPlatformsBoundsLeft;
        [SerializeField] private Transform movingPlatformsBoundsRight;
        [Space]
        [SerializeField] private bool drawGizmos; // Знаю що можна вимкнути в редакторі, просто щоб не забивало інші гізмозм коли показуються
        private Queue<PlatformBase> _platformQueue;
        private Vector3 _highestPlatformPosition;
        private int _nonDuplicatesCount;

        public Transform CollisionStartTarget => collisionStartTarget;
        public Transform MovingPlatformsBoundsLeft => movingPlatformsBoundsLeft;
        public Transform MovingPlatformsBoundsRight => movingPlatformsBoundsRight;
        public float GameScoreMultiplier => factory.scoreMultiplier;

        public void Init()
        {
            _platformQueue = new Queue<PlatformBase>(factory.maxPlatformCount);
            factory.Init();
            GeneratedStartingPlatforms();
        }

        private void GeneratedStartingPlatforms()
        {
            _nonDuplicatesCount = 0;
            _highestPlatformPosition = transform.position + startPlatformPosition;
            SpawnPlatformAt(factory.startingPlatform, _highestPlatformPosition);
            for (var i = 0; i < factory.preferredPlatformAmount - 1; i++)
            {
                SpawnNewPlatform();
            }
        }

        private void SpawnNewPlatform()
        {
            var newPlatform = SpawnPlatformAt(factory.GetRandomPlatformType(), GetNewPlatformPosition());
            if (newPlatform && Random.Range(0, 1f) <= factory.duplicateChance * newPlatform.DuplicateChanceMultiplier)
            {
                var duplicatePosition = GetNewPlatformPosition(newPlatform.transform.position + Vector3.down * factory.verticalDistance.x);
                SpawnPlatformAt(factory.GetRandomPlatformType(), duplicatePosition, true);
            }
        }

        private PlatformBase SpawnPlatformAt(PlatformType type, Vector2 position, bool isDuplicated = false)
        {
            var platform = factory.CreatePlatform(type);
            return SpawnPlatformAt(platform, position, isDuplicated);
        }

        private PlatformBase SpawnPlatformAt(PlatformBase platform, Vector2 position, bool isDuplicated = false)
        {
            if (container.childCount == factory.maxPlatformCount)
            {
                Debug.LogWarning("[Platform Controller]. Platform limit is reached");
                return null;
            }
            var instance = Instantiate(platform, position, Quaternion.identity, container);
            instance.Init(this, isDuplicated);
            if (instance.transform.position.y > _highestPlatformPosition.y) _highestPlatformPosition = instance.transform.position;
            if (!isDuplicated) _nonDuplicatesCount++;
            _platformQueue.Enqueue(instance);
            return instance;
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
            if (_nonDuplicatesCount <= factory.preferredPlatformAmount && (platform && platform.ReplaceWithNewWhenDestroyed))
            {
                _nonDuplicatesCount--;
                SpawnNewPlatform();
            }
            if (platform) Destroy(platform.gameObject);
        }

        private Vector2 GetNewPlatformPosition()
        {
            return GetNewPlatformPosition(_highestPlatformPosition);
        }

        private Vector2 GetNewPlatformPosition(Vector3 startFrom)
        {
            var distance = Random.Range(factory.verticalDistance.x, factory.verticalDistance.y);
            var x = Random.Range(factory.horizontalDistance.x, factory.horizontalDistance.y);
            return new Vector2(x, startFrom.y + distance);
        }

        private void OnDrawGizmos()
        {
            if (!drawGizmos) return;
            var transformPosition = transform.position;
            // Точка спавну стартової платформи
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(startPlatformPosition + transformPosition, .1f);
            
            Gizmos.color = Color.blue;
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
