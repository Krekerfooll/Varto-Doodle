using UnityEngine;

namespace PVitaliy.Platform
{
    public abstract class PlatformBase : MonoBehaviour
    {
        public abstract PlatformType Type { get; }
        protected PlatformController Controller; // знадобиться для генерації у ДЗ9

        public void Init(PlatformController controller)
        {
            Controller = controller;
            AfterInit();
        }

        protected virtual void AfterInit() {}
    }
}