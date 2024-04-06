using PVitaliy.Platform;
using UnityEngine;

namespace PVitaliy
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private PlatformController platformController;

        private void Awake()
        {
            platformController.Init();
        }
    }
}