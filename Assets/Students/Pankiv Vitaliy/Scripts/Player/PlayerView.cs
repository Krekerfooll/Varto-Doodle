using System;
using UnityEngine;

namespace PVitaliy.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        private void Awake()
        {
            if (!playerMovement) throw new Exception("[Player] Missing movement script");
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