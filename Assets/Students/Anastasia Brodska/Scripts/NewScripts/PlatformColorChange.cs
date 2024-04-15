using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColorChange : PlatformOnColision
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
