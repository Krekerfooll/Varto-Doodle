using System.Collections.Generic;
using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_CheckObjectDeactivate : MonoBehaviour
    {
        [SerializeField] public GameObject _targetIsDeactivated;
        [SerializeField] private List<OI_ActionBase> _afterDestroyActions;

        [SerializeField] private float delay;
        void Update()
        {
            if (_targetIsDeactivated.activeSelf) return;
            else
            {
                foreach (var action in _afterDestroyActions)
                {
                    action.Invoke("Execute", delay);
                }
            }
        }
    }
}