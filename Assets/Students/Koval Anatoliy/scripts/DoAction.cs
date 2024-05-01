using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoAction : MonoBehaviour
{
    [SerializeField] ActionBase _action;

    private void Awake()
    {
        _action.Execute();
    }
}
