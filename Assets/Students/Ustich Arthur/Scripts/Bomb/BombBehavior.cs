using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class BombBehavior : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private RuntimeAnimatorController _explosionAnimation;

        private bool _isExplosion = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player" && !_isExplosion)
            {
                _animator.runtimeAnimatorController = _explosionAnimation;
                _isExplosion = true;
                _animator.StopPlayback();
            }
        }
    }
}