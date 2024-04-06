using PVitaliy.Colors;
using UnityEngine;

namespace PVitaliy.Platform
{
    public abstract class PlatformBase : MonoBehaviour
    {
        [SerializeField] protected ColorTarget spriteColorController;
        [SerializeField] protected Collider2D _collider;
        private bool _initialized = false;
        public Color TargetColor => spriteColorController.TargetColor;
        public abstract PlatformType Type { get; }
        private Transform _collisionEnablingPoint;
        protected PlatformController Controller; // ну десь же точно знадобиться... мабуть
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
            _collider.enabled = ColliderEnabled;
            OnUpdate();
        }
        
        protected virtual void AfterInit() {}
        protected virtual void OnUpdate() {}
    }
}