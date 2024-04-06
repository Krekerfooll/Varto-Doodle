using UnityEngine;

namespace PVitaliy.Colors
{
    public class SpriteWithHighlightTarget : SpriteColorTarget
    {
        [SerializeField] private SpriteRenderer highlightRenderer;
        [SerializeField][Min(0)] private float brightness = 1f;
        private Color _targetHighlightColor;

        protected override void AfterAwake()
        {
            _targetHighlightColor = MainColor * brightness;
        }

        public override void ChangeTargetColor(Color newColor)
        {
            base.ChangeTargetColor(newColor);
            _targetHighlightColor = newColor * brightness;
        }

        protected override void Update()
        {
            base.Update();
            highlightRenderer.color = Color.Lerp(highlightRenderer.color, _targetHighlightColor, interpolationPower * Time.deltaTime * 60);
        }
    }
}