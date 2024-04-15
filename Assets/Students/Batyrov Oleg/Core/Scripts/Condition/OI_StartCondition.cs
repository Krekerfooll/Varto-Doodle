using OIMOD.Core.Component;
using System.Collections.Generic;
using UnityEngine;

public class OI_StartCondition : MonoBehaviour
{
    [SerializeField] private List<OI_ActionBase> _startActions;
    [SerializeField] private float delay;
    void Start()
    {
        foreach (var action in _startActions)
        {
            action.Invoke("Execute", delay);
        }
    }
}
