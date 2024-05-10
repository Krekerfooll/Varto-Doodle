using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlatformBase : MonoBehaviour
{
    [SerializeField] protected bool _executeOnAwake;
    [SerializeField] protected bool _executeOnleOnes;

    protected bool _isExecutedOnes;

    void Awake()
    {
        if (_executeOnAwake)
        { 
        _executeOnleOnes = true;
        ExecuteInternal();
        }
    }

    public void Execute()
    {
        if (_isExecutedOnes && _executeOnleOnes) return;

        _isExecutedOnes = true;
        ExecuteInternal();
    }

    protected abstract void ExecuteInternal();
}
