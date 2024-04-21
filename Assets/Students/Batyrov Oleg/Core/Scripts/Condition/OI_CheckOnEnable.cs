using System.Collections.Generic;
using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_CheckOnEnable : MonoBehaviour
    {
        [SerializeField] private List<OI_ActionBase> _actions;
        [SerializeField] private float delay;
        void OnEnable()
        {
            foreach (var action in _actions)
            {
                action.Invoke("Execute", delay);
            }
        }
    }
}