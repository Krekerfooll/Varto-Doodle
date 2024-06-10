using UnityEngine;

namespace RomanDoliba.Utils
{
    public abstract class OnTriggerAction : ActionBase
    {
        [SerializeField] private LayerMask _onTriggerEnterWith;

        protected Collider2D LastCollider {get; private set;}

        private void OnTriggerEnter2D (Collider2D collider)
        {
            if  ((_onTriggerEnterWith.value & (1 << collider.gameObject.layer)) != 0)
            {
                LastCollider = collider;
                Execute();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if ((_onTriggerEnterWith.value & (1 << collision.gameObject.layer)) != 0)
            {
                Execute();
            }
        }
    }
}
