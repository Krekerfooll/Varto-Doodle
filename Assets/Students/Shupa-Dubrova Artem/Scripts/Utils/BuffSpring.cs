using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Utils
{
    public class BuffSpring : OnTriggerEnterAction
    {
        [SerializeField] private float _buffJumpPower;
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _target;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        public override void Execute()
        {
            ExecuteSpring();
        }

        private void ExecuteSpring()
        {
            _target = Collider.gameObject.GetComponent<Transform>();
            _rigidbody2D = Collider.gameObject.GetComponent<Rigidbody2D>();

            if (transform.position.y <= _target.position.y)
            {
                _animator.SetBool("isUnloaded", false);
                _animator.SetBool("isUnloaded", true);
                Vector2 velocity = _rigidbody2D.velocity;
                velocity.y = _buffJumpPower;
                _rigidbody2D.velocity = velocity;
            }
            
        }
    }
}
