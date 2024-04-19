using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Utils
{
    public abstract class OnCollisionAction : ActionBase
    {
        [SerializeField] private LayerMask _onCollisionEnterWith;
        [SerializeField] protected bool _executeOnce;

        protected Collision2D Collision { get; private set; }
        
        private bool _isActivated;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(_executeOnce && _isActivated)
                return;

            if ((_onCollisionEnterWith.value & (1 << collision.gameObject.layer)) != 0)
            {
                Collision = collision;
                Execute();
            }
        }
    }
    
}
