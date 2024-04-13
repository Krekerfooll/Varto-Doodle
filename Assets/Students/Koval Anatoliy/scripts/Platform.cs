using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] protected Transform _target;
    [SerializeField] protected GameObject _collider;

    protected bool _isInitiated;

    public void Init(Transform target)
    {
        _target = target;
        _isInitiated = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (_isInitiated)
        //{
            OnUpdatePlatform();
        //}
    }

    protected virtual void OnUpdatePlatform()
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
