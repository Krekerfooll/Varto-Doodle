using System;
using UnityEngine;

namespace PVitaliy.Utils
{
    [Serializable]
    public struct MinMax<T>
    {
        [SerializeField] private T min;
        [SerializeField] private T max;
        public T Min => min;
        public T Max => max;
    }
    
    [Serializable]
    public struct MinMaxNormalized<T>
    {
        [SerializeField][Range(0, 1)] private T min;
        [SerializeField][Range(0, 1)] private T max;
        public T Min => min;
        public T Max => max;
    }
}