using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Player
{
    public class BuffSpring : BuffBase
    {
        [SerializeField] private Rigidbody2D _playerTarget;
        [SerializeField] private float _springJumpPower;
        
        protected override void ApplyBuff()
        {
            // Vector2 velocity = _playerTarget.velocity;
            // velocity.y = _springJumpPower;
            // _playerTarget.velocity = velocity;
            
            // _playerTarget.AddForce(Vector2.up * _springJumpPower, ForceMode2D.Impulse);
            Debug.Log("IS TRIGGERED");
        }
    }
}
