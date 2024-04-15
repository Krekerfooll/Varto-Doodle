using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OIMOD.Core.Component 
{
    public class OI_PlayAnimationAction : OI_ActionBase
    {
        [SerializeField] private Animator animator;
        [SerializeField] private string animationParameter;
        protected override void ExecuteInternal()
        {
            animator.SetBool(animationParameter, true);
        }
    }
}