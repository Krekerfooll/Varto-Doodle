using PVitaliy.Colors;
using UnityEngine;

namespace PVitaliy.Platform
{
    public abstract class PlatformBase : MonoBehaviour
    {
        [SerializeField] protected ColorTarget spriteColorController;
        [SerializeField] protected Collider2D _collider;
        [SerializeField] private bool emitParticlesOnLanding = true;
        private bool _initialized;
        public Color TargetColor => spriteColorController.TargetColor;
        public bool EmitParticlesOnLanding => emitParticlesOnLanding;
        public abstract PlatformType Type { get; }
        private Transform _collisionEnablingPoint;
        protected PlatformController Controller;
        protected virtual bool ColliderEnabled => transform.position.y <= _collisionEnablingPoint.position.y;

        public void Init(PlatformController controller)
        {
            Controller = controller;
            _collisionEnablingPoint = controller.CollisionStartTarget;
            AfterInit();
            _initialized = true;
        }

        private void Update()
        {
            if (!_initialized) return;
            OnUpdate();
        }

        private void FixedUpdate()
        {
            if (!_initialized) return;
            _collider.enabled = ColliderEnabled;
            OnFixedUpdate();
        }

        protected virtual void AfterInit() {}
        protected virtual void OnUpdate() {}
        protected virtual void OnFixedUpdate() {}
    }
}