using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public abstract class ConditionBaseSO : ScriptableObject
    {
        public abstract bool Check(object data = null);
    }
}