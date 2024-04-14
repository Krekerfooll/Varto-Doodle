using UnityEngine;

namespace Scripts
{
    public static class ColorController
    {
        public static void ChangeColorByStep(SpriteRenderer _spriteRenderer, ref float color, float step)
        {
            color -= step;
            _spriteRenderer.color = new Color(color, color, color);
            if (color <= 0) color = 1f;
        }

        public static void ChangeColorByRandom(ref Color color)
        {
            color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        public static void ChangeColorForCameraBackgroundByRandom()
        {
            Color color = new Color();
            ChangeColorByRandom(ref color);
            Camera.main.backgroundColor = color;
        }
    }
}
