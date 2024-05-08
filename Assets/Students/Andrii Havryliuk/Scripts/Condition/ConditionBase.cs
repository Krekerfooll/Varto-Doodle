using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConditionBase : MonoBehaviour
{
    [SerializeField] protected List<ActionBase> _action;

    public void Condition()
    {
        foreach (var act in _action)
        {
            act.Execute();
        }
    }

}
