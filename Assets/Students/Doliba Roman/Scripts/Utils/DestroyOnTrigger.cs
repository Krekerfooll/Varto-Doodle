using UnityEngine;

namespace RomanDoliba.Utils
{
    public class PlayerKillOnTrigger : OnTriggerAction
    {
        [SerializeField] private float _delay;
        [SerializeField] private bool _destroyItself;
        
        private void Destroy()
        {
            if (_destroyItself)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(LastCollider.gameObject, _delay);
            }
        }
        protected override void Execute()
        {
            Destroy();
        }
    }
}
