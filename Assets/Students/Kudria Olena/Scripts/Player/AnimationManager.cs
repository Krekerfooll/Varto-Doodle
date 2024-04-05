using UnityEngine;

namespace Students.Kudria_Olena.Scripts.Player
{
    public class AnimationManager : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private static readonly int Speed = Animator.StringToHash("Speed");

        private void OnEnable()
        {
            InputManager.OnMovingTrigger += MoveAnimation;
        }

        private void MoveAnimation(float horizontalInput)
        {
            animator.SetFloat(Speed, Mathf.Abs(horizontalInput));
        }
        
        private void OnDisable()
        {
            InputManager.OnMovingTrigger -= MoveAnimation;
        }
    }
}