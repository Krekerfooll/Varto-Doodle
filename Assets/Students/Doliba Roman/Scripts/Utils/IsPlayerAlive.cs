using UnityEngine;

namespace RomanDoliba.Utils
{
    public class IsPlayerAlive : ActionBase
    {
        [SerializeField] private GameObject _player;
        private bool _isDead;
        private void Update()
        {
            if (!_player.activeInHierarchy)
            {
                _isDead = true; 
                Execute();
                enabled = false;
            }
        }

        protected override void Execute()
        {
            if (_isDead)
            {
                Debug.Log("PlayerDead");
            }
        }
        public bool IsDead {get {return _isDead;} private set{}}
    }
}
