using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    [SerializeField] protected Transform _target; // ����, ������� ����������� ���������, �������� �����.
    [SerializeField] protected GameObject _collider; // ��������� ���������, ��������� � ����������� �������� ����������� �������.

    [Space]
    [SerializeField] protected List<Varto_ActionBase> _executeOnCollisionActivated; // ������ �������� ��� ��������� ����������.
    [SerializeField] protected List<Varto_ActionBase> _executeOnCollisionDeactivated; // ������ �������� ��� ����������� ����������.

    protected bool _isInitiated = false; // ����, ����������� �� ������������� ���������.
    protected bool _isActivatedOnce = false; // ����, ����������� �� ����������� ��������� ���������.

    // ����� ��� ������������� ���������
    public void InitPlatform(Transform target)
    {
        _target = target;
        _isInitiated = true;
    }

    void Update()
    {
        if (_isInitiated)
        {
            UpdatePlatformState();
        }
    }

    protected virtual void UpdatePlatformState()
    {
        if (_isActivatedOnce && !_collider.activeSelf)
        {
            return; // ���������� ����������, ���� ��������� �� ������ �������� ��������������
        }

        // ��������� ������� ���� ������������ ���������
        if (_target.position.y > transform.position.y)
        {
            ActivateCollider();
        }
        else if (_target.position.y < transform.position.y)
        {
            DeactivateCollider();
        }
    }

    protected void ActivateCollider()
    {
        if (!_collider.activeSelf)
        {
            _collider.SetActive(true);
            _isActivatedOnce = true;
            ExecuteActions(_executeOnCollisionActivated);
        }
    }

    protected void DeactivateCollider()
    {
        if (_collider.activeSelf)
        {
            _collider.SetActive(false);
            ExecuteActions(_executeOnCollisionDeactivated);
        }
    }

    // ����� ��� ���������� ������ ��������
    protected void ExecuteActions(List<Varto_ActionBase> actions)
    {
        foreach (var action in actions)
        {
            action.Execute();
        }
    }
}

public abstract class Varto_ActionBase : MonoBehaviour
{
    public abstract void Execute();
}