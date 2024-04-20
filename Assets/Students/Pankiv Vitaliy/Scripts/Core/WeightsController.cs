using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PVitaliy.Factory
{
    [Serializable]
    public struct WeightData<TK>
    {
        public TK data;
        public float weight;
    }
    
    [Serializable]
    public class WeightsController<TK>
    {
        [SerializeField] private List<WeightData<TK>> weights;
        private float _totalWeight;

        public void UpdateWeights()
        {
            _totalWeight = weights.Sum(weightData => weightData.weight);
            weights.Sort((w1, w2) => w1.weight < w2.weight ? -1 : 1);
        }

        public TK GetRandom()
        {
            var selectedWeight = Random.Range(0, _totalWeight);
            float currentWeight = 0;
            foreach (var weightedPlatformData in weights)
            {
                currentWeight += weightedPlatformData.weight;
                if (currentWeight >= selectedWeight)
                {
                    return weightedPlatformData.data;
                }
            }
            return weights[^1].data;
        }
    }
}