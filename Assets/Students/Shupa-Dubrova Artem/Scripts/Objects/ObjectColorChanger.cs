using UnityEngine;

namespace Students.Shupa_Dubrova_Artem.Scripts.Objects
{
    public class ObjectColorChanger : OnCollisionEvents
    {
        [SerializeField] private Renderer _objectToChangeColor;
        [SerializeField] private Color _color;

        public void ChangeColor()
        {
            ChangeColor(_color);
        }
        public void ChangeColor(Color color)
        {
            if (_objectToChangeColor is SpriteRenderer spriteRenderer)
            {
                spriteRenderer.color = color;
            }
            else
            {
                _objectToChangeColor.material.color = color;
            }
        }

        protected override void ExecuteInternal()
        {
            ChangeColor();
        }
    }
}
