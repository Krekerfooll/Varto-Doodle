using System.Collections.Generic;
using PVitaliy.Factory;
using UnityEngine;

namespace PVitaliy.Platform
{
    public class PlatformGenerator : FactoryGenerator<PlatformFactory, PlatformBase, PlatformType>
    {
        [Header("Platform Generator")]
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
            PreGeneratePlatforms();
        }

        private void PreGeneratePlatforms()
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
            var newPlatform = SpawnPlatformAt(GenerateRandom(), GetNewPlatformPosition());
            if (newPlatform && Random.Range(0, 1f) <= factory.duplicateChance * newPlatform.DuplicateChanceMultiplier)
            {
                var duplicatePosition = GetNewPlatformPosition(newPlatform.transform.position + Vector3.down * factory.verticalDistance.Min);
                SpawnPlatformAt(GenerateRandom(), duplicatePosition, true);
            }
        }

        private PlatformBase SpawnPlatformAt(PlatformBase platform, Vector2 position, bool isDuplicated = false)
        {
            if (container.childCount == factory.maxPlatformCount)
            {
                Debug.LogWarning("[Platform Controller]. Platform limit is reached");
                return null;
            }
            var instance = Instantiate(platform, position, Quaternion.identity, container);
            instance.Init(this, !isDuplicated);
            NewPlatformInitiatedHandler(instance);
            
            if (!isDuplicated) _nonDuplicatesCount++;
            else instance.name += " D";
            
            return instance;
        }

        private void NewPlatformInitiatedHandler(PlatformBase instance)
        {
            if (instance.transform.position.y > _highestPlatformPosition.y) _highestPlatformPosition = instance.transform.position;
            _platformQueue.Enqueue(instance);
        }

        private void FixedUpdate()
        {
            var bottomPlatform = _platformQueue.Peek();
            if (bottomPlatform.transform.position.y < removeAtPoint.position.y)
            {
                RemoveLastPlatformAndGenerateNew();
            }
        }

        private void RemoveLastPlatformAndGenerateNew()
        {
            var platform = _platformQueue.Dequeue();
            Destroy(platform.gameObject);
            if (_nonDuplicatesCount <= factory.preferredPlatformAmount && platform.ReplaceWithNewWhenDestroyed)
            {
                _nonDuplicatesCount--;
                SpawnNewPlatform();
            }
        }

        private Vector2 GetNewPlatformPosition()
        {
            return GetNewPlatformPosition(_highestPlatformPosition);
        }

        private Vector2 GetNewPlatformPosition(Vector3 startFrom)
        {
            var distance = Random.Range(factory.verticalDistance.Min, factory.verticalDistance.Max);
            var x = Random.Range(factory.horizontalDistance.Min, factory.horizontalDistance.Max);
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
            Gizmos.DrawLine(new Vector3(factory.horizontalDistance.Min, factory.verticalDistance.Min) + transformPosition,
                new Vector3(factory.horizontalDistance.Max, factory.verticalDistance.Min) + transformPosition);
            
            // Вертикальні ліміти генерації платформ
            var avgX = (factory.horizontalDistance.Min + factory.horizontalDistance.Max) / 2;
            var startPoint = new Vector3(avgX, factory.verticalDistance.Min) + transformPosition;
            Gizmos.DrawLine(startPoint, new Vector3(avgX, factory.verticalDistance.Max) + transformPosition);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(startPoint, new Vector3(avgX, 0) + transformPosition);
        }
    }
}