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
        [SerializeField] private PlatformSpawner _spawner;
        [SerializeField] private PlayerMovement _playerMoveMovement;
        private int _currentColor = 0;
        int _randColor = 0;


        private void Update()
        {
            ChangeGameObjColor();
        }

        private void ChangeGameObjColor()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _playerMoveMovement.IsGrounded)
            {
                UniqeColor();
                _playerAnimator.runtimeAnimatorController = _playerIdleAnimation[_currentColor];
                foreach (GameObject _platforms in _spawner.Platforms)
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
    }
}