using System.Collections;
using PVitaliy.Actions.Core;
using UnityEngine;

namespace PVitaliy.Actions
{
    public class BreakObject : ActionBase
    {
        [SerializeField] private ParticleSystem breakingPS;
        [SerializeField] private GameObject viewContainer;
        [SerializeField] private Collider2D _collider;
        [SerializeField] [Min(0)] private float secondsBeforeViewTurnOff = .3f;
        [SerializeField] [Min(0)] private float secondsBeforeObjectTurnOff = 1f;

        protected override void ExecuteInternal()
        {
            StartCoroutine(nameof(BreakingCoroutine));
        }

        private IEnumerator BreakingCoroutine()
        {
            breakingPS.Play();
            yield return new WaitForSeconds(secondsBeforeViewTurnOff);
            _collider.isTrigger = true;
            viewContainer.SetActive(false);
            yield return new WaitForSeconds(secondsBeforeObjectTurnOff);
            gameObject.SetActive(false);
        }
    }
}