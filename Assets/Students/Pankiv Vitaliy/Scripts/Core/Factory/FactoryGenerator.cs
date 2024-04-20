using System;
using PVitaliy.Actions.Core;
using UnityEngine;

namespace PVitaliy.Factory
{
    public abstract class FactoryGenerator<TF, TO, TK> : MonoBehaviour where TF : FactoryBase<TO, TK> where TO : FactoryObject<TK>
    {
        [Header("Generator")]
        [SerializeField] protected TF factory;
        [SerializeField] private ActionExecutorBase OnGenerated;

        protected TO GenerateRandom()
        {
            var type = factory.GetRandomType();
            return GenerateInstanceOfType(type);
        }

        protected TO GenerateInstanceOfType(TK type)
        {
            var instance = factory.GetInstance(type);
            if (!instance)
            {
                throw new Exception("[Generator] Instance of type " + type + " is not in the list");
            }
            OnGenerated?.Execute();
            return instance;
        }
    }
}