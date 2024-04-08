using System.Collections;
using PVitaliy.Player;
using UnityEngine;

namespace PVitaliy.Platform
{
    public class PlatformFalling : PlatformStatic
    {
        [SerializeField] private ParticleSystem breakingPS;
        [SerializeField] private GameObject bodyContainer;
        public override PlatformType Type => PlatformType.Falling;
        private bool _isFalling;
        protected override bool ColliderEnabled => _isFalling || base.ColliderEnabled;

        protected override void OnPlayerLanded(PlayerMovement player)
        {
            _isFalling = true;
            StartCoroutine(nameof(BreakingCoroutine));
        }

        private IEnumerator BreakingCoroutine()
        {
            breakingPS.Play();
            yield return new WaitForSeconds(.3f);
            _collider.isTrigger = true;
            bodyContainer.SetActive(false);
            yield return new WaitForSeconds(1f);
            gameObject.SetActive(false);
        }
    }
}