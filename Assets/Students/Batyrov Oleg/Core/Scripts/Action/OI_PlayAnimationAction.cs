using UnityEngine;

namespace OIMOD.Core.Component 
{
    public class OI_PlayAnimationAction : OI_ActionBase
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string animationToPlay;
        protected override void ExecuteInternal()
        {
            if (gameObject.activeSelf)
                animator.Play(animationToPlay);
        }
    }
}