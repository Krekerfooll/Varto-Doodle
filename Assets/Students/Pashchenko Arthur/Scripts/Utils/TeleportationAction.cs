using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Artur.Pashchenko.Utils
{
    public class TeleportationAction : ActionBase
    {
        [SerializeField] private float _endPointPositionX;
        [SerializeField] private Transform _target;
        public override void Execute()
        {
            Vector2 _endPointPosition = new Vector2(_endPointPositionX, _target.position.y);
            _target.position = _endPointPosition;
        }
    }
}