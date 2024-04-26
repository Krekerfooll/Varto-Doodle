using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace Artur.Pashchenko.Utils
{
    public class ObjectDestroyer : CollisionTrigerActionBase
    {
        public enum DestroyType {This, CollidedObject}

        [SerializeField] DestroyType _destroyType;
        private float _time = 10f;

        public void Destroy()
        {
            switch (_destroyType) 
            {
                case DestroyType.This:
                    Destroy(gameObject, _time); 
                    break;

                case DestroyType.CollidedObject:
                    Destroy(LastCollision.gameObject, _time);
                    break;
            }
        }
        public override void Execute()
        {
            Destroy();
        }

    }
}