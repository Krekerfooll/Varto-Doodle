using UnityEngine;

namespace RomanDoliba.Utils
{
    public class ChangeColor : OnTriggerAction
    {
        [SerializeField] private Color _color;
        [SerializeField] private Renderer _objectToChangeColor;

        private void ChangeColorOn()
        {
            if(_objectToChangeColor is SpriteRenderer spriteRenderer)
            {
                spriteRenderer.color = _color;
            }
            else
            {
                _objectToChangeColor.material.color = _color;
            }
        }
        
        
        protected override void Execute()
        {
            ChangeColorOn();
        }
    }
}
