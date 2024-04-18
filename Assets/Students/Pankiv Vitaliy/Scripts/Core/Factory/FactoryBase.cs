using System.Collections.Generic;
using UnityEngine;

namespace PVitaliy.Factory
{
    public abstract class FactoryBase<TO, TK> : ScriptableObject where TO : FactoryObject<TK>
    {
        [SerializeField] protected List<TO> Values;
        public virtual TK GetRandomType()
        {
            return Values.ToArray()[Random.Range(0, Values.Count)].Type();
        }

        public TO GetInstance(TK type)
        {
            return Values.Find(value => value.Type().Equals(type));
        }
        public abstract void Init();
    }
}