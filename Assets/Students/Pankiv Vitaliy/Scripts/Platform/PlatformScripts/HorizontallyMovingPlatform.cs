using PVitaliy.Components;
using UnityEngine;

namespace PVitaliy.Platform
{
    public class HorizontallyMovingPlatform : PlatformBase
    {
        [Header("Horizontal Moving Platform")]
        [SerializeField] protected SlidingHorizontally slider;

        protected override void AfterInit()
        {
            base.AfterInit();
            slider.SetPoints(Generator.MovingPlatformsBoundsLeft, Generator.MovingPlatformsBoundsRight);
        }
    }
}