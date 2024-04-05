using UnityEngine;

namespace Students.Kudria_Olena.Scripts.Player
{
    public class FlipManager : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer player;
        
        private void OnEnable() => InputManager.OnMovingTrigger += Flip;

        private void Flip(float horizontalInput)
        {
            player.flipX = horizontalInput switch
            {
                > 0 => false,
                < 0 => true,
                _ => player.flipX
            };
        }
        
        private void OnDisable() => InputManager.OnMovingTrigger -= Flip;
    }
}