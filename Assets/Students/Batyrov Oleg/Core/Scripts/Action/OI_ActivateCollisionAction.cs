using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_ActivateCollisionAction : OI_ActionBase
    {
        [SerializeField] private Collider2D _collider;
        protected override void ExecuteInternal() 
        {
            if (_collider != null)
                _collider.enabled = true;
        } 
        
    }
}
