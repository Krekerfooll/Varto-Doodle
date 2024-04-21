using System.Collections.Generic;
using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_CheckOnAwake : MonoBehaviour
    {
        [SerializeField] private List<OI_ActionBase> actions;

        private void Awake()
        {
            foreach (var action in actions) action.Execute();
        }
    }
}