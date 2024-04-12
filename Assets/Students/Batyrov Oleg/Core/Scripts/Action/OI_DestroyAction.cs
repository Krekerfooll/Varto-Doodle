using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_DestroyAction : OI_ActionBase
    {
        [SerializeField] private GameObject _targetToDestroy;
        [SerializeField] private float _delay;

        protected override void ExecuteInternal()
        {
            Destroy(_targetToDestroy, _delay);
        }
    }
}

