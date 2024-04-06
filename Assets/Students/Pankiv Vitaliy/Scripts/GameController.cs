using PVitaliy.Colors;
using PVitaliy.Platform;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PVitaliy
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Vector3 startPlatformPosition;
        [SerializeField] private PlatformController platformController;

        private void Awake()
        {
            platformController.SpawnPlatformAt(PlatformType.Static, startPlatformPosition);
        }

        public void ChangeColors()
        {
            foreach (var colorTarget in ColorManager.Targets)
            {
                var color = Random.ColorHSV(0, 1, .2f, 1, .4f, 1);
                colorTarget.ChangeTargetColor(color);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(startPlatformPosition, .1f);
        }
    }
}