using UnityEngine;

namespace PVitaliy.Colors
{
    public class GradientMeshMaterialColorTarget : ColorTarget
    {
        [SerializeField] private MeshRenderer rendererWithMaterial;
        private Color _currentTopColor;
        private Color _targetTopColor;
        protected override Color MainColor
        {
            get => rendererWithMaterial.materials[0].GetColor("_colorBottom"); //Можливо потім на два кольори перероблю, з кастомним градієнтом, а не текстурою
            set => rendererWithMaterial.materials[0].SetColor("_colorBottom", value);
        }

        protected override void AfterAwake()
        {
            base.AfterAwake();
            _currentTopColor = rendererWithMaterial.materials[0].GetColor("_colorTop");
        }

        public override void ChangeTargetColor(Color newColor)
        {
            base.ChangeTargetColor(newColor);
            float h, s, v;
            Color.RGBToHSV(newColor, out h, out s, out v);
            h = (h + .3f) % 1;
            _targetTopColor = Color.HSVToRGB(h, s, v);
        }

        protected override void Update()
        {
            base.Update();
            _currentTopColor = Color.Lerp(_currentTopColor, _targetTopColor, LerpPower);
            rendererWithMaterial.materials[0].SetColor("_colorTop", _currentTopColor);
        }
    }
}