using UnityEngine;

namespace Varto.Examples.Utils
{
    public class Varto_ObjectColorChanger : Varto_OnCollisionEventsActionBase
    {
        [SerializeField] private Renderer _objectToChangeColor;
        [SerializeField] private Color _color;

        public void ChangeColor()
        {
            if (_objectToChangeColor is SpriteRenderer spriteRenderer)
            {
                spriteRenderer.color = _color;
            }
            else
            {
                _objectToChangeColor.material.color = _color;
            }
        }

        protected override void ExecuteInternal()
        {
            ChangeColor();
        }
    }
}
