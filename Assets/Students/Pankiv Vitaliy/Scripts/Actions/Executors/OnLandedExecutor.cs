using PVitaliy.Actions.Core;
using UnityEngine;

namespace PVitaliy.Executors
{
    public class OnLandedExecutor : ActionExecutor
    {
        [SerializeField] private LayerMask collideWith;
        [SerializeField] private bool useTrigger;

        private bool CanExecute(GameObject target)
        {
            var rigidBody = target.GetComponent<Rigidbody2D>();
            return rigidBody.velocity.y <= 1 && Globals.IsSameLayer(target.layer, collideWith);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (useTrigger || _executeOnce && _executedOnce) return;
            if (!CanExecute(other.gameObject)) return;
            
            SetActionsTarget(other.gameObject);
            ExecuteActions(actions);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!useTrigger || _executeOnce && _executedOnce) return;
            if (!CanExecute(other.gameObject)) return;
            
            SetActionsTarget(other.gameObject);
            ExecuteActions(actions);
        }
    }
}