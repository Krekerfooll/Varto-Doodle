using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smooth;

    private void FixedUpdate()
    {
        var targetPositin = new Vector3(transform.position.x, _target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPositin, _smooth);
    }
}
