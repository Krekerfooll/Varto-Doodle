using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class ChangeColorManager : MonoBehaviour
    {
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private SpriteRenderer _blocksSpriteRenderer;
        [SerializeField] private List<RuntimeAnimatorController> _playerIdleAnimation = new List<RuntimeAnimatorController>();
        [SerializeField] private List<SpriteRenderer> _blocks = new List<SpriteRenderer>();
        [SerializeField] private List<Sprite> _blockSprites = new List<Sprite>();


        private void Update()
        {
            ChangeGameObjColor();
        }

        private void ChangeGameObjColor()
        {
            int randColor = Random.Range(0, _playerIdleAnimation.Count);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerAnimator.runtimeAnimatorController = _playerIdleAnimation[randColor];
                foreach (SpriteRenderer sprite in _blocks)
                {
                    sprite.sprite = _blockSprites[randColor];
                }
            }  
        }
    }
}