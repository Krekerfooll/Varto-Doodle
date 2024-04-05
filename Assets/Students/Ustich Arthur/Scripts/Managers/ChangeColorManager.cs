using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.Player
{
    public class ChangeColorManager : MonoBehaviour
    {
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private SpriteRenderer _blocksSpriteRenderer;
        [SerializeField] private List<RuntimeAnimatorController> _playerIdleAnimation = new List<RuntimeAnimatorController>();
        [SerializeField] private List<GameObject> _blocks = new List<GameObject>();



        private void Update()
        {
            FindBlocks();
            ChangePlayerAnimation();
        }

        private void ChangePlayerAnimation()
        {
            int randAnimation = Random.Range(0, _playerIdleAnimation.Count);
            if (Input.GetKeyDown(KeyCode.Space))
                _playerAnimator.runtimeAnimatorController = _playerIdleAnimation[randAnimation];
        }

        private void FindBlocks()
        {

        }
    }
}