using PVitaliy.Colors;
using UnityEngine;

namespace PVitaliy.Platform
{
    public abstract class PlatformBase : MonoBehaviour
    {
        [SerializeField] protected ColorTarget spriteColorController;
        [SerializeField] protected Collider2D _collider;
        [SerializeField] private bool emitParticlesOnLanding = true;
        [SerializeField] private float duplicateChanceMultiplier = 1;
        private bool _initialized;
        private Transform _collisionEnablingPoint;
        public bool ReplaceWithNewWhenDestroyed { get; private set; }
        protected PlatformController Controller;
        protected virtual bool ColliderEnabled => transform.position.y <= _collisionEnablingPoint.position.y;
        
        public Color TargetColor => spriteColorController.TargetColor;
        public bool EmitParticlesOnLanding => emitParticlesOnLanding;
        public float DuplicateChanceMultiplier => duplicateChanceMultiplier;
        public abstract PlatformType Type { get; }

        public void Init(PlatformController controller, bool replaceWithNew)
        {
            Controller = controller;
            _collisionEnablingPoint = controller.CollisionStartTarget;
            ReplaceWithNewWhenDestroyed = replaceWithNew;
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