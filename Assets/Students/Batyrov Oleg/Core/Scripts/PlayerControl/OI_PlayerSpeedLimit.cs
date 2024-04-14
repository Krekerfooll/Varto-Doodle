using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_PlayerSpeedLimit : MonoBehaviour
    {
        [SerializeField] private OI_GameData gameData;
        private Rigidbody2D _playerRb;
        private float _maxVelocity;

        private void Awake()
        {
            _playerRb = gameData.playerRigidBody;
            _maxVelocity = gameData.playerMaxVelocity;
        }
        private void FixedUpdate() => SpeedLimit();
        private void SpeedLimit() => _playerRb.velocity = Vector2.ClampMagnitude(gameData.playerRigidBody.velocity, _maxVelocity);
    }
}

