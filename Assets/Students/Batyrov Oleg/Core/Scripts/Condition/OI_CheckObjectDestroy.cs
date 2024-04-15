using System.Collections.Generic;
using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_CheckObjectDestroy : MonoBehaviour
    {
        [SerializeField] public GameObject _targetIsNull;
        [SerializeField] private List<OI_ActionBase> _afterDestroyActions;

        [SerializeField] private float delay;
        void Update()
        {
            if (_targetIsNull != null) return;
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

