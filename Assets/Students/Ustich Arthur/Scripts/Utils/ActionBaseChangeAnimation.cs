using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class ActionBaseChangeAnimation : ActionBase
    {
        [SerializeField] private Animator _objectAnimator;
        [SerializeField] private RuntimeAnimatorController _objectAnimation;

        public override void ExecuteInternal()
        {
            ChangeAnimation();
        }

        private void ChangeAnimation()
        {
            _objectAnimator.runtimeAnimatorController = _objectAnimation;
        }
    }
}