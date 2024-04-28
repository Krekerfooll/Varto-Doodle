using UnityEngine;
namespace Artur.Pashchenko.Conditions
{
    public class IsGroudedCondition : ConditionBase
    {
        [SerializeField] private Rigidbody2D _playerRigidbody;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _distanceForRaycast;
        public override bool CheckCondition()
        {
            return Physics2D.Raycast(_playerRigidbody.position, Vector2.down, _distanceForRaycast, _groundMask);
        }
       
    }
}