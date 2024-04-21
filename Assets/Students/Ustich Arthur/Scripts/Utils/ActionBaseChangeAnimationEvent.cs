using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class ActionBaseChangeAnimationEvent : ActionBaseCollisionEvent
    {
        [SerializeField] private Animator _objectAnimator;
        [SerializeField] private RuntimeAnimatorController _objectAnimation;
        [SerializeField] private GameObject _destroyCollision;

        private void Awake()
        {
            _destroyCollision.SetActive(false);
        }

        public override void ExecuteInternal()
        {
            ChangeAnimation();
        }

        public void ChangeAnimation()
        {
            _objectAnimator.runtimeAnimatorController = _objectAnimation;
            _destroyCollision.SetActive(true);
        }
    }
}