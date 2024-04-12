using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Varto.Camera
{
    public class Varto_CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _speed;
        [Space]
        [SerializeField] private bool _followByX;
        [SerializeField] private bool _followByY;
        [SerializeField] private bool _followByZ;

        void Update()
        {
            var targetPosition = new Vector3(transform.position.x, _target.position.y, transform.position.z);
            transform.position = targetPosition;
        }
    }
}

