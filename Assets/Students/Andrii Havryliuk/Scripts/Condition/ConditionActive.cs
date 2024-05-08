using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionActive : ConditionBase
{
    [SerializeField] private bool _isActive;

    private void Update()
    {
        if (_isActive)
            Condition();
    }

}
