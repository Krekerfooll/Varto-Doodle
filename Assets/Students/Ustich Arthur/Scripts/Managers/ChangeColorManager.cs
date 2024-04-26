using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class ChangeColorManager : MonoBehaviour
    {
        [Header("Color settings:")]
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private List<RuntimeAnimatorController> _playerIdleAnimation = new List<RuntimeAnimatorController>();
        [SerializeField] private List<Sprite> _blockSprites = new List<Sprite>();
        [Space]
        [Header("Additional component:")]
        [SerializeField] private SpawnManager _spawner;
        [SerializeField] private PlayerMovement _playerMoveMovement;
        private int _currentColor = 0;
        int _randColor = 0;
        private bool _colorWasChanged = false;


        private void Update()
        {
            ChangeGameObjColor();
            CheckJumping();
        }

        private void ChangeGameObjColor()
        {
            if (_playerMoveMovement.IsGrounded)
            {
                UniqeColor();
                if (!_colorWasChanged)
                {
                    _playerAnimator.runtimeAnimatorController = _playerIdleAnimation[_currentColor];
                    _colorWasChanged = true;


                    foreach (GameObject _platforms in _spawner.SpawnedObjects)
                    {
                        bool changable = _platforms.GetComponent<ColorChangable>().CanChangeColor;
                        if (changable)
                        {
                            SpriteRenderer _sprite = _platforms.GetComponent<SpriteRenderer>();
                            _sprite.sprite = _blockSprites[_currentColor];
                        }
                    }
                }
            }  
        }

        private void UniqeColor()
        {
            _randColor = Random.Range(0, _playerIdleAnimation.Count);
            if (_randColor != _currentColor)
                _currentColor = _randColor;
            else if (_randColor == _currentColor && _randColor == _playerIdleAnimation.Count - 1)
            {
                _randColor--;
                _currentColor = _randColor;
            }
            else 
            {
                _randColor++;
                _currentColor = _randColor;
            }
        }

        private void CheckJumping()
        {
            if (_playerMoveMovement.IsJumping)
                _colorWasChanged = false;
        }
    }
}