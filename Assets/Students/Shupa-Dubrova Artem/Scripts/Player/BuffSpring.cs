using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Player
{
    public class BuffSpring : BuffBase
    {
        [SerializeField] private Rigidbody2D _playerTarget;
        [SerializeField] private string _onTriggerEnterWith;
        [SerializeField] private float _springJumpPower;
        
        private bool _isTriggered;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag($"{_onTriggerEnterWith}"))
            {
                _isTriggered = true;
            }
        }
        
        protected override void ApplyBuff()
        {
            if (_isTriggered)
            {
                Vector2 velocity = _playerTarget.velocity;
                velocity.y = _springJumpPower;
                _playerTarget.velocity = velocity;
                Debug.Log("IS TRIGGERED");
            }
        }
    }
}
