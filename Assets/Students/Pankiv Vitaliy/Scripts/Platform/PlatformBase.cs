using PVitaliy.Factory;
using UnityEngine;
using UnityEngine.Serialization;

namespace PVitaliy.Platform
{
    public class PlatformBase : FactoryObject<PlatformType> // do NEVER destroy gameObject from here again
    {
        [FormerlySerializedAs("onPlayerLanded")]
        [Header("Platform Base")]
        [SerializeField] protected Collider2D _collider;
        [SerializeField] private float duplicateChanceMultiplier = 1;
        [SerializeField] private PlatformType type;
        
        private bool _initialized;
        private Transform _collisionEnablingPoint;
        protected PlatformGenerator Generator;
        private bool ColliderEnabled => transform.position.y <= _collisionEnablingPoint.position.y;
        public float DuplicateChanceMultiplier => duplicateChanceMultiplier;
        public bool ReplaceWithNewWhenDestroyed { get; private set; }

        public override PlatformType Type()
        {
            return type;
        }

        public void Init(PlatformGenerator controller, bool replaceWithNew)
        {
            Generator = controller;
            _collisionEnablingPoint = controller.CollisionStartTarget;
            ReplaceWithNewWhenDestroyed = replaceWithNew;
            AfterInit();
            _initialized = true;
        }

        private void FixedUpdate()
        {
            if (!_initialized) return;
            _collider.enabled = ColliderEnabled;
        }

        protected virtual void AfterInit() {}
    }
}