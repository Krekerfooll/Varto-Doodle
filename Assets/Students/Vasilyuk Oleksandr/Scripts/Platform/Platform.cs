using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] protected Transform _target;
    [SerializeField] protected GameObject _collider;
    [Space]
    [SerializeField] protected bool _staysActive = true;
    [Space]
    [SerializeField] protected List<ActionBase> _executeOnCollisionActivated;
    [SerializeField] protected List<ActionBase> _executeOnCollisionDeactivated;

    protected bool _isInitiated;
    protected bool _isActivatedOnes;

    public void Init(Transform target)
    {
        _target = target;
        _isInitiated = true;
    }

    private void Update()
    {
        if (_isInitiated)
        {
            OnPlatform();
        }
    }
    protected virtual void OnPlatform()
    {
        if (_staysActive && _isActivatedOnes)
            return;

        if (_target != null)
        {
            if (_target.position.y > transform.position.y)
            {
                _collider.SetActive(true);
                _isActivatedOnes = true;

                foreach (var action in _executeOnCollisionActivated)
                    action.Execute();

            }
            else
            {
                _collider.SetActive(false);

                foreach (var action in _executeOnCollisionDeactivated)
                    action.Execute();
            }
        }
    }
}
