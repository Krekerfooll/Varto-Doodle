using PVitaliy.Actions.Core;
using UnityEngine;

namespace PVitaliy.Actions
{
    public class EmitParticles : ActionBase
    {
        [SerializeField] private ParticleSystem _particleSystem;
        public int particleAmount;
        protected override void ExecuteInternal()
        {
            _particleSystem.Emit(particleAmount);
        }
    }
}