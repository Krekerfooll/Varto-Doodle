using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_DestroyColliderAction : OI_ActionBase
    {
        [SerializeField] public Collider2D _targetToDestroy;
        [SerializeField] private float _delay;

        protected override void ExecuteInternal()
        {
            Destroy(_targetToDestroy, _delay);
        }
    }
}

