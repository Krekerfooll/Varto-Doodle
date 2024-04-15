using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
        [Space]
        public Vector3 offset;

        private void FixedUpdate()
        {
            Vector3 desiredPosition = _target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _speed);
            transform.position = smoothedPosition;
        }
    }
}

