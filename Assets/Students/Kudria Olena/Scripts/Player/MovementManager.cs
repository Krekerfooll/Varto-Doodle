using UnityEngine;

namespace Students.Kudria_Olena.Scripts.Player
{
    public class MovementManager : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private Rigidbody2D player;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpSpeed;
        [SerializeField] private float groundDistance;
        [SerializeField] private LayerMask groundMask;
        
        private void FixedUpdate()
        {
            Move();
            Jump();
        }

        private void Move()
        {
            player.velocity = new Vector2(inputManager.HorizontalInput * moveSpeed, player.velocity.y);
        }

        private void Jump()
        {
            if (!IsGrounded()) return;
            if (inputManager.JumpInput)
                player.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }

        private bool IsGrounded()
        {
            var position = player.transform.position;
            Debug.DrawLine(position, position + Vector3.down * groundDistance,
                Color.red);
            
            return Physics2D.Raycast(player.position, Vector2.down,
                groundDistance, groundMask);
        }
    }
}