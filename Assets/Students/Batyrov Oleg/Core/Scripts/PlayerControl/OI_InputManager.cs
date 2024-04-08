using UnityEngine;

namespace OIMOD.Core.GameMech
{
    public class OI_InputManager : MonoBehaviour
    {
        private bool _inputJump;
        private float _inputMove;

        protected float MoveInput 
        {
            get 
            {
                return _inputMove = Input.GetAxis("Horizontal");
            }
        }
        protected bool JumpInput 
        {
            get 
            {
                return _inputJump = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
            }
        }
    }
}

