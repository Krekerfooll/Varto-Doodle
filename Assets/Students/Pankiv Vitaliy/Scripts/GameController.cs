using PVitaliy.Platform;
using UnityEngine;

namespace PVitaliy
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Vector3 startPlatformPosition;
        [SerializeField] private PlatformController platformController;
        [SerializeField] [Min(2)] private int maxPlatformCount = 8;

        private void Awake()
        {
            platformController.Init(startPlatformPosition, maxPlatformCount);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(startPlatformPosition, .1f);
        }
    }
}