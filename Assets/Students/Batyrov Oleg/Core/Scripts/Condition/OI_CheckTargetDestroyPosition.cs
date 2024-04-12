using System.Collections.Generic;
using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_CheckTargetDestroyPosition : MonoBehaviour
    {
        [SerializeField] public Transform _targetToDestroyTransform;
        [SerializeField] public Transform _targetDestroyAtTransform;

        [SerializeField] private List<OI_ActionBase> _onDestroyAction;

        private void Update()
        {
            var targetA = _targetToDestroyTransform.position.y;
            var targetDestroy = _targetDestroyAtTransform.position.y;

            if (targetA <= targetDestroy)
            {
                foreach (var action in _onDestroyAction)
                {
                    action.Execute();
                }
            }
        }
    }
}