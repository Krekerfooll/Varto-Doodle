using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Artur.Pashchenko.Utils
{
    public class TurnOnCollisionAction : ActionBase
    {
        [SerializeField] private bool _turnOn;
        [SerializeField] private Collider2D[] _collider;
        public override void Execute()
        {
            if (_turnOn)
            {
                for (int i = 0; i < _collider.Length; i++)
                {
                    _collider[i].enabled = true;
                }

            }

            else if (!_turnOn)
            {
                for (int i = 0; i < _collider.Length; i++)
                {
                    _collider[i].enabled = false;
                }

            }
        }
    }
}