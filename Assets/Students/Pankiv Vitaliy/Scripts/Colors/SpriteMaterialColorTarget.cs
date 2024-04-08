using UnityEngine;

namespace PVitaliy.Colors
{
    public class SpriteMaterialColorTarget : ColorTarget
    {
        [SerializeField] private SpriteRenderer rendererWithMaterial;
        protected override Color MainColor
        {
            get => rendererWithMaterial.material.GetColor("_color"); //Можливо потім на два кольори перероблю, з кастомним градієнтом, а не текстурою
            set { rendererWithMaterial.material.SetColor("_color", value); }
        }
    }
}