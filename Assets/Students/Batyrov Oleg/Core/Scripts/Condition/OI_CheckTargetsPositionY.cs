using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace OIMOD.Core.Component
{
    public class OI_CheckTargetsPositionY : MonoBehaviour
    {
        [SerializeField] public Transform _targetATransform;
        [SerializeField] public Transform _targetBTransform;

        [SerializeField] private List<OI_ActionBase> _aIsHigherActions;
        [SerializeField] private List<OI_ActionBase> _bIsHigherActions;

        private void Update()
        {
            var targetA = _targetATransform.position.y;
            var targetB = _targetBTransform.position.y;

            if (targetA > targetB)
            {
                foreach (var action in _aIsHigherActions)
                {
                    action.Execute();
                }
            }
            else
            {
                foreach (var action in _bIsHigherActions)
                {
                    action.Execute();
                }
            }
        }
    }
}

