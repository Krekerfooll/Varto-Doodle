using UnityEngine;

namespace RomanDoliba.Utils
{
    public class ChangeColor : OnTriggerAction
    {
        [SerializeField] private Color _color;
        [SerializeField] private Renderer _objectToChangeColor;

        public void ChangeColorOn()
        {
            ChangeColorOn(_color);
        }

        public void ChangeColorOn(Color color)
        {
            if(_objectToChangeColor is SpriteRenderer spriteRenderer)
            {
                spriteRenderer.color = color;
            }
            else
            {
                _objectToChangeColor.material.color = color;
            }
        }
        
        protected override void Execute()
        {
            ChangeColorOn();
        }
    }
}
