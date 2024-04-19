using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Utils
{
    public abstract class OnTriggerEnterAction : ActionBase
    {
        [SerializeField] protected string _onTriggerEnterWithTag;
        [SerializeField] protected bool _executeOnce;
        
        protected Collider2D Collider { get; private set; }
        
        private bool _isActivated;
        
        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag($"{_onTriggerEnterWithTag}"))
            {
                if(_executeOnce && _isActivated)
                    return;
                _isActivated = true;
                Collider = other;
                Execute();
            }
        }
    }
}

