using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionOnColision : ConditionBase
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Condition();
    }

}
