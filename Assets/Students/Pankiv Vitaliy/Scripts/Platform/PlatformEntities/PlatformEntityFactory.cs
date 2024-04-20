using PVitaliy.Factory;
using PVitaliy.Utils;
using UnityEngine;

namespace PVitaliy.Platform.Entities
{
    [CreateAssetMenu(fileName = "Platform Entity", menuName = "Platform/Entity/Entity Factory")]
    public class PlatformEntityFactory : FactoryBase<PlatformEntityBase, PlatformEntityType>
    {
        [SerializeField] private MinMax<float> horizontalSpawnRange;
        [SerializeField] [Range(0, 1f)] private float generationChance;
        public MinMax<float> HorizontalSpawnRange => horizontalSpawnRange;
        public float GenerationChance => generationChance;
        public override void Init() {}
    }

    public enum PlatformEntityType
    {
        Spring
    }
}