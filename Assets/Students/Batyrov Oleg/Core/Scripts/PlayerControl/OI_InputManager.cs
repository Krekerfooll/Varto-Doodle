using UnityEngine;

namespace OIMOD.Core.GameMech
{
    public class OI_InputManager : MonoBehaviour
    {
        private bool _inputJump;
        private float _inputMove;

        public float MoveInput 
        {
            get 
            {
                return _inputMove = Input.GetAxis("Horizontal");
            }
        }
        public bool JumpInput 
        {
            get 
            {
                return _inputJump = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
            }
        }
    }
}

