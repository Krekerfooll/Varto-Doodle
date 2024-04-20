using PVitaliy.Factory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PVitaliy.Platform.Entities
{
    public class PlatformEntityGenerator : FactoryGenerator<PlatformEntityFactory, PlatformEntityBase, PlatformEntityType>
    {
        [Header("Platform Entity Generator")]
        [SerializeField] private Transform entityContainer;
        
        private void Start()
        {
            TryGenerateEntity();
        }

        private void TryGenerateEntity()
        {
            if (Random.value > factory.GenerationChance) return;
            var prefab = GenerateRandom();
            if (!prefab) return;
            
            var instance = Instantiate(prefab, entityContainer.transform.position, Quaternion.identity, entityContainer);
            instance.transform.localPosition = Vector3.right * Random.Range(factory.HorizontalSpawnRange.Min, factory.HorizontalSpawnRange.Max);
        }

        private void OnDrawGizmos()
        {
            var scaleX = transform.localScale.x;
            var position = entityContainer.transform.position;
            Gizmos.color = Color.green;
            Gizmos.DrawLine(
                position + factory.HorizontalSpawnRange.Min * scaleX * Vector3.right,
                position + factory.HorizontalSpawnRange.Max * scaleX * Vector3.right);
        }
    }
}