using UnityEngine;

namespace Scripts
{
    public static class ColorController
    {
        public static void ChangeColor(SpriteRenderer _spriteRenderer, ref float _color)
        {
            _color -= 0.1f;
            _spriteRenderer.color = new Color(_color, _color, _color);
            if (_color == 0) _color = 1f;
        }
    }
}
