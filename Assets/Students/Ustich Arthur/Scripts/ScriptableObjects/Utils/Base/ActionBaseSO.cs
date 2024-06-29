using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public abstract class ActionBaseSO : ScriptableObject
    {
        public abstract void Execute(object data = null);
    }
}