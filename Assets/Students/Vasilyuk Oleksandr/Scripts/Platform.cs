using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _collider;

    protected bool _isInitiated;

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
    private void OnPlatform()
    {
        if (_target.position.y > transform.position.y)
            _collider.SetActive(true);
        else
            _collider.SetActive(false);
    }
}
