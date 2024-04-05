using System;
using UnityEngine;

namespace Students.Kudria_Olena.Scripts.Player
{
    public class InputManager : MonoBehaviour
    {
        public float HorizontalInput { get; private set; }
        public bool JumpInput { get; private set; }
        
        public static Action<float> OnMovingTrigger;

        private void Update()
        {
            CalculateHorizonalMovement();
            CalculateJump();
        }

        private void CalculateHorizonalMovement()
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal");
            OnMovingTrigger?.Invoke(HorizontalInput);
        }

        private void CalculateJump()
        {
            JumpInput = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W);
        }
    }
}