using System.Collections.Generic;
using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_CheckOnTriggerEnter : MonoBehaviour
    {
        [SerializeField] public GameObject _targetObject;
        [SerializeField] private List<OI_ActionBase> _onTriggerActions;
        [SerializeField] private float delay;

        private void OnTriggerEnter2D(Collider2D target)
        {
            if (_targetObject == null) return;

            var targetCollision = _targetObject.GetComponent<Collider2D>();
            if (target == targetCollision)
            {
                foreach (var action in _onTriggerActions)
                {
                    action.Invoke("Execute",delay);
                }
            }
        }
    }
}

