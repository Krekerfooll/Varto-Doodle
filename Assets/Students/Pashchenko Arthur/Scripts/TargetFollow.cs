using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;


    private void Update()
    {
        var targetPosition = new Vector3(this.transform.position.x, _target.position.y, this.transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
    }





}
