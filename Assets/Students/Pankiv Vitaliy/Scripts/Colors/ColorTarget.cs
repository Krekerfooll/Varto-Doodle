using UnityEngine;

namespace PVitaliy.Colors
{
    public abstract class ColorTarget : MonoBehaviour
    {
        [SerializeField] protected float interpolationPower = .15f;
        [SerializeField] private bool addOnAwake = false;
        private Color _targetColor;
        public Color TargetColor => _targetColor;

        protected abstract Color MainColor { get;set; }

        private void Awake()
        {
            _targetColor = MainColor;
            if (addOnAwake) ColorManager.Targets.Add(this);
            AfterAwake();
        }

        protected virtual void AfterAwake(){}

        public virtual void ChangeTargetColor(Color newColor)
        {
            _targetColor = newColor;
        }

        protected virtual void Update()
        {
            MainColor = Color.Lerp(MainColor, _targetColor, interpolationPower * Time.deltaTime * 60);
        }
    }
}
