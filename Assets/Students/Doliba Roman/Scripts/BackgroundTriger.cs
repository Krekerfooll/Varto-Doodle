using UnityEngine;

namespace RomanDoliba.Background
{
    public class BackgroundTriger : MonoBehaviour
    {
        [SerializeField] private BackgoundChange backgoundChange;
        [SerializeField] private Player.MovementController movementController;
              
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (movementController._isGrounded)
            {
                backgoundChange.BackgoundsChange();
            }
        }
    }
}
