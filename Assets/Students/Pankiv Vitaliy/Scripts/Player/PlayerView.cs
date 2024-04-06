using System;
using UnityEngine;

namespace PVitaliy.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private Transform viewContainer;
        [SerializeField] [Range(0, 1)] private float directionLerpPower = .5f;
        private float _targetScaleX = 1;
        private void Awake()
        {
            if (!playerMovement) throw new Exception("[Player] Missing movement script");
        }

        public void ChangeDirection(bool lookRight)
        {
            _targetScaleX = lookRight ? -1 : 1;
        }

        private void Update()
        {
            var newScaleX = Mathf.Lerp(viewContainer.localScale.x, _targetScaleX, directionLerpPower * Time.deltaTime * 60);
            viewContainer.localScale = new Vector3(newScaleX, viewContainer.localScale.y);
        }

        private void OnDrawGizmos()
        {
            var positionLeft = playerMovement.LeftRayStartPoint;
            var positionRight = playerMovement.RightRayStartPoint;
            Gizmos.DrawLine(positionLeft, positionLeft + Vector3.down * playerMovement.RaycastDistance);
            Gizmos.DrawLine(positionRight, positionRight + Vector3.down * playerMovement.RaycastDistance);
        }
    }
}