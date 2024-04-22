using PVitaliy.Factory;
using UnityEngine;

namespace PVitaliy.Platform
{
    [CreateAssetMenu(fileName = "Platform", menuName = "Platform/Weighted Factory")]
    public class WeightedPlatformFactory : PlatformFactory
    {
        [Header("Weighted Platform Factory")]
        [SerializeField] private WeightsCollection<PlatformType> weights;

        public override void Init()
        {
            weights.UpdateWeights();
        }

        public override PlatformType GetRandomType()
        {
            return weights.GetRandomData();
        }
    }
}