using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private float _cameraSpeed;
    void Update()
    {
        var targetPosition = new Vector3(transform.position.x, _target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, _cameraSpeed*Time.deltaTime);
    }
}
