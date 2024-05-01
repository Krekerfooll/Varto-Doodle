using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Artur.Pashchenko.Utils;

namespace Artur.Pashchenko.Conditions
{
    public class TeleportationCondition : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _borderXLeft;
        [SerializeField] private float _borderXRight;
        [SerializeField] private ActionBase[] _teleportationToRightAction;
        [SerializeField] private ActionBase[] _teleportationToLeftAction;

        private void Update()
        {
            float _targetPositionX = _target.position.x;
            if (_borderXLeft > _targetPositionX) 
            {
                for (int i = 0; i < _teleportationToRightAction.Length; i++)
                {
                    _teleportationToRightAction[i].Execute();
                }
            }
            else if(_borderXRight < _targetPositionX) 
            {
                for (int i = 0; i < _teleportationToLeftAction.Length; i++)
                {
                    _teleportationToLeftAction[i].Execute();
                }
            }

        }
    }
}