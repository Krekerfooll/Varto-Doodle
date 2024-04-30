using UnityEngine;
using System.Collections.Generic;

namespace Examples.Player
{
    public class PlatformTrigger : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private GameObject colliderObject;

        [Space]
        [Tooltip("Should the collider stay active after it has been activated once?")]
        [SerializeField] private bool staysActive = true;

        private bool isActivatedOnce = false; // Whether the collider was activated at least once.

        public void Init(Transform target)
        {
            playerTransform = target;
        }

        void Update()
        {
            OnUpdatePlatform();
        }

        // Method for updating the platform state.
        protected void OnUpdatePlatform()
        {
            if (staysActive && isActivatedOnce)
                return;

            if (playerTransform.position.y > transform.position.y)
            {
                colliderObject.SetActive(true);
                isActivatedOnce = true;
            }
            else
            {
                colliderObject.SetActive(false);
            }
        }
    }
}