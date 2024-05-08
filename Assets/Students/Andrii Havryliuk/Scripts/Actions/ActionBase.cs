using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBase : MonoBehaviour
{
    [SerializeField] protected bool _executeOnAwake;
    [SerializeField] protected bool _executeOnlyOnes;

    protected bool _isExecutedOnes;

    private void Awake()
    {
        if (_executeOnAwake)
        {
            _isExecutedOnes = true;
            ExecuteInternal();
        }
    }

    public void Execute()
    {
        if(_executeOnlyOnes && _isExecutedOnes)
            return;

        _isExecutedOnes = true;
        ExecuteInternal();
    }

    protected abstract void ExecuteInternal();
}
