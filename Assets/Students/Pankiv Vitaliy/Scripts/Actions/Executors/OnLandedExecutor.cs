using PVitaliy.Actions.Core;
using UnityEngine;

namespace PVitaliy.Executors
{
    public class OnLandedExecutor : ActionExecutor
    {
        [SerializeField] private LayerMask collideWith;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_executeOnce && _executedOnce) return;
            if (other.rigidbody.velocity.y <= 1 && Globals.IsSameLayer(other.gameObject.layer, collideWith)) ExecuteActions(actions);
        }
    }
}