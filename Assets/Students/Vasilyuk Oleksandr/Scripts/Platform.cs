using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _collider;

    private void Update()
    {
        OnPlatform();
    }
    private void OnPlatform()
    {
        if (_target.position.y > transform.position.y)
            _collider.SetActive(true);
        else
            _collider.SetActive(false);
    }
}
