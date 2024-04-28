using Artur.Pashchenko.Conditions;
using Artur.Pashchenko.Player;
using Artur.Pashchenko.Utils;
using System.Collections.Generic;
using UnityEngine;
namespace Artur.Pashchenko.Platform
{
    public abstract class Platform : MonoBehaviour
    {
        [SerializeField] protected GameObject _player;
        [SerializeField] protected Rigidbody2D _playerRigidbody;
        [SerializeField] protected Collider2D _playerCollider;
        [SerializeField] protected GameObject _targetPlatform;
        [SerializeField] protected CompareHightCondition _compareHightCondition;
        [SerializeField] protected CollisionCondition _collisionCondition;
        public void Init (PlayerData playerData) 
        {
            _player = playerData._player;
            _playerCollider = playerData._playerCollider;
            _playerRigidbody = playerData._playerRigidbody;
            _targetPlatform = playerData._targetPlatform;
            if (_compareHightCondition != null)
            {
                _compareHightCondition._target = _targetPlatform;
            }
            if (_collisionCondition != null)
            {
                _collisionCondition._target = playerData._player;
            }
        }
      
    }
}