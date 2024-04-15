using OIMOD.Core.Component;
using UnityEngine;

namespace OIMOD.Core.GameMech
{
    public class OI_PlatformHighJump : OI_PlatformCore
    {
        [SerializeField] private OI_CheckOnTriggerEnter _checkOnTriggerEnter;
        [SerializeField] private OI_PlayerHighJumpAction _playerHighJumpAction;
        [Space]
        [SerializeField] protected Rigidbody2D _playerRb;
        [SerializeField] protected int _playerJumpForce;
        public override void Init(OI_GameData gameData)
        {
            base.Init(gameData);

            _checkOnTriggerEnter._targetObject = gameData.playerInstance;
            _playerHighJumpAction._player = gameData.playerInstance;
            _playerHighJumpAction._jumpForce = gameData.playerJumpForce;

            _playerRb = gameData.playerRigidBody;
            _playerJumpForce = gameData.playerJumpForce;

        }
    }
}

