using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : OnCollisionEventsActionBase
{
    [SerializeField] private Renderer _object;
    [SerializeField] private Color _color;

    public void ChangeColor()
    {
        ChangeColor(_color);
    }
    public void ChangeColor(Color color)
    {
        if (_object is SpriteRenderer spriteRenderer)
        {
            spriteRenderer.color = color;
        }
        else
        {
            _object.material.color = color;
        }
    }

    protected override void ExecuteInternal()
    {
        ChangeColor();
    }
}

