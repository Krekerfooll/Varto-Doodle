using System.Collections;
using PVitaliy.Player;
using UnityEngine;

namespace PVitaliy.Platform
{
    public class HorizontalMovingFallingPlatform : HorizontallyMovingPlatform
    {
        [SerializeField] private ParticleSystem breakingPS;
        [SerializeField] private GameObject bodyContainer;
        private bool _isFalling;
        protected override bool ColliderEnabled => _isFalling || base.ColliderEnabled;
        public override PlatformType Type => PlatformType.HorizontalMovingFalling;

        protected override void MoveStandingPlayer() {}

        protected override void OnPlayerLanded(PlayerMovement player)
        {
            CurrentDirectionX = 0;
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