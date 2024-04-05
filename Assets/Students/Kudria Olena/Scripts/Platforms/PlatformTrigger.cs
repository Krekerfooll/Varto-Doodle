using System;
using UnityEngine;

namespace Students.Kudria_Olena.Scripts.Platforms
{
    public class PlatformTrigger : MonoBehaviour
    {
        public static Action OnPlatformTrigger;

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnPlatformTrigger?.Invoke();
        }
    }
}
