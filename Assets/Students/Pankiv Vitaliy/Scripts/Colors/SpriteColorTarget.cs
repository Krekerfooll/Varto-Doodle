using UnityEngine;

namespace PVitaliy.Colors
{
    public class SpriteColorTarget : ColorTarget
    {
        [SerializeField] private SpriteRenderer mainRenderer;

        protected override Color MainColor
        {
            get => mainRenderer.color;
            set => mainRenderer.color = value;
        }
    }
}