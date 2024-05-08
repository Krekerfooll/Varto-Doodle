using UnityEngine;

public class ActionColorChange : ActionBase
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _color;
    

    protected override void ExecuteInternal()
    {
        _spriteRenderer.color = _color;
    }
}
