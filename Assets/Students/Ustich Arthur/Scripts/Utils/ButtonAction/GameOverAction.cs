using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class GameOverAction : ButtonActionBase
    {
        [SerializeField] private GameObject _target;
        public override void ExecuteInternal()
        {
            if (_target == null)
                DisableEnableObjects();
        }
    }
}