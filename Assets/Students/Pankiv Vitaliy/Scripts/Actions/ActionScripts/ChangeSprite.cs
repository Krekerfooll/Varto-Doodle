using PVitaliy.Actions.Core;
using UnityEngine;

namespace PVitaliy.Actions
{
    public class ChangeSprite : ActionBase
    {
        [SerializeField] private SpriteRenderer target;
        [SerializeField] private Sprite changeTo;

        protected override void ExecuteInternal()
        {
            target.sprite = changeTo;
        }
    }
}