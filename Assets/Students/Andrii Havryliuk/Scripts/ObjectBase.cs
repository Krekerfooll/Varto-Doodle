using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class ObjectBase : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private List<ConditionBase> _listCondition;

    public bool _isInitiated { get; private set; }
    protected Transform _target;
    public void Init(Transform target)
    {
        _target = target;
        _isInitiated = true;
    }

    private void Update()
    {
        if (_isInitiated)
            OnUpdate();
    }

    private void OnUpdate()
    {
        _collider.enabled = _target.position.y > transform.position.y;
        OnUpdateInternal();
    }
    protected abstract void OnUpdateInternal();

}
