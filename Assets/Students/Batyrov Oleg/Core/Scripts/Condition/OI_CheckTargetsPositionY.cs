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

        [SerializeField] private float delay;

        private void Update()
        {
            if (_targetATransform == null || _targetBTransform == null) return;

            float targetA = _targetATransform.position.y;
            float targetB = _targetBTransform.position.y;

            if (targetA > targetB)
            {
                foreach (var action in _aIsHigherActions)
                {
                    action.Invoke("Execute", delay);
                }
            }
            else
            {
                foreach (var action in _bIsHigherActions)
                {
                    action.Invoke("Execute", delay);
                }
            }
        }
    }
}

