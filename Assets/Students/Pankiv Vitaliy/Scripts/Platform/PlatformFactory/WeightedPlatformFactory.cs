using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PVitaliy.Platform
{
    [Serializable]
    public struct WeightedPlatformData
    {
        public PlatformType type;
        public float weight;
    }
    [CreateAssetMenu(fileName = "Platform", menuName = "Platform/Weighted Factory")]
    public class WeightedPlatformFactory : PlatformFactory
    {
        [Header("Weighted Platform Factory")]
        public List<WeightedPlatformData> weights;
        private float _totalWeight;

        public override void Init()
        {
            _totalWeight = 0;
            weights.ForEach(weightData => _totalWeight += weightData.weight);
            weights.Sort((w1, w2) => w1.weight < w2.weight ? -1 : 1);
        }

        public override PlatformType GetRandomPlatformType()
        {
            var selectedWeight = Random.Range(0, _totalWeight);
            float currentWeight = 0;
            foreach (var weightedPlatformData in weights)
            {
                currentWeight += weightedPlatformData.weight;
                if (currentWeight >= selectedWeight)
                {
                    return weightedPlatformData.type;
                }
            }
            return weights[^1].type;
        }
    }
}