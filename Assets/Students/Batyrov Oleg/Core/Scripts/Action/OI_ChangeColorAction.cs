using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_ChangeColorAction : OI_ActionBase
    {
        [SerializeField] private Color _color;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        protected override void ExecuteInternal()
        {
            _spriteRenderer.color = _color;
        }
    }
}

