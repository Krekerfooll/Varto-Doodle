using Stanislav.Alokhin.Utils;
using UnityEngine;

namespace Alokhin.Stanislav.Utils
{
    public abstract class OnCollisionEventsActionBase : ActionBase
    {
        [Space]
        [SerializeField] private LayerMask _onCollisionEnterWith;
        [SerializeField] private bool _isTrigger;

        protected bool isTrigger => _isTrigger;
        protected Collision2D LastCollision {  get; private set; }
        protected Collider2D LastTrigger { get; private set; }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!_isTrigger && (_onCollisionEnterWith.value & ( 1<< collision.gameObject.layer )) != 0)
            {
                LastCollision = collision;
                Execute();
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_isTrigger && (_onCollisionEnterWith.value & (1 << collision.gameObject.layer)) != 0)
            {
                LastTrigger = collision;
                Execute();
            }
        }
    }
}

