using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSwitcher : ActionBase
{
    [SerializeField] protected Transform _target;
    [SerializeField] protected GameObject _collider;

    public void Init(Transform target)
    {
        _target = target;
    }
    
     public override void Execute()
    {
        if (_target.transform.position.y > transform.position.y)
        {
            _collider.SetActive(true);
        }
        else
        {
            _collider.SetActive(false);
        }
    }
}
