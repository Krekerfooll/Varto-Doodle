using UnityEngine;

namespace PVitaliy.Factory
{
    public abstract class FactoryObject<T> : MonoBehaviour
    {
        public abstract T Type();
    }
}