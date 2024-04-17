using System.Collections.Generic;
using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_InputManager : MonoBehaviour
    {
        [SerializeField] private OI_GameData gameData;
        [SerializeField] private List<OI_ActionBase> _JumpInputAction;
        [SerializeField] private List<OI_ActionBase> _MoveInputAction;
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
        private void Update()
        {
            if (gameData.playerIsAlive && JumpInput && _JumpInputAction != null)
            {
                foreach (var action in _JumpInputAction)
                {
                    action.Execute();
                }
            }
            if (gameData.playerIsAlive &&  MoveInput != 0 && _MoveInputAction != null)
            {
                foreach (var action in _MoveInputAction)
                {
                    action.Execute();
                }
            }
            
        }
    }
}

