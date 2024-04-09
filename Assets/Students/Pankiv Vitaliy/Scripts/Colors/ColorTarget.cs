using UnityEngine;

namespace PVitaliy.Colors
{
    public abstract class ColorTarget : MonoBehaviour
    {
        [SerializeField] protected float interpolationPower = .15f;
        private Color _targetColor;
        protected float LerpPower => interpolationPower * Time.deltaTime * 60;
        public Color TargetColor => _targetColor;

        protected abstract Color MainColor { get;set; }

        private void Awake()
        {
            _targetColor = MainColor;
            AfterAwake();
        }

        protected virtual void AfterAwake(){}

        public virtual void ChangeTargetColor(Color newColor)
        {
            _targetColor = newColor;
        }

        protected virtual void Update()
        {
            MainColor = Color.Lerp(MainColor, _targetColor, LerpPower);
        }
        
    }
}
