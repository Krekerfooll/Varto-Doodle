using PVitaliy.Factory;
using UnityEngine;

namespace PVitaliy.Platform
{
    [CreateAssetMenu(fileName = "Platform", menuName = "Platform/Weighted Factory")]
    public class WeightedPlatformFactory : PlatformFactory
    {
        [Header("Weighted Platform Factory")]
        [SerializeField] private WeightsController<PlatformType> weights;

        private void Awake()
        {
            weights.UpdateWeights();
        }

        public override PlatformType GetRandomType()
        {
            return weights.GetRandom();
        }
    }
}