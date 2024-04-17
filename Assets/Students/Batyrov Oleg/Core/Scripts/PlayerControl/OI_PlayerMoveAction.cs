using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_PlayerMoveAction : OI_ActionBase
    {
        [SerializeField] private OI_InputManager inputManager;
        [SerializeField] private OI_GameData gameData;

        private Rigidbody2D _playerRb;
        private float _speed;
        private Transform _playerRender;

        private void Awake()
        {
            _playerRb = gameData.playerRigidBody;
            _speed = gameData.playerSpeed;
            _playerRender = gameData.playerRender.transform;
        }
        private void Update()
        {
            if (!gameData.playerIsAlive && gameData.playerInstance != null)
            {
                _playerRb.velocity = Vector3.zero;
            }
        }
        protected override void ExecuteInternal()
        {
            if (_playerRb == null) return;

            _playerRb.velocity = new Vector2(inputManager.MoveInput * _speed, _playerRb.velocity.y);
            if (inputManager.MoveInput > 0) _playerRender.localScale = new Vector3(-1, 1, 1);
            else if (inputManager.MoveInput < 0) _playerRender.localScale = new Vector3(1, 1, 1);
        }
    }
}

