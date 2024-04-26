using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Artur.Pashchenko.Utils
{
    public abstract class CollisionTrigerActionBase : ActionBase
    {
        [SerializeField] private LayerMask _onCollisionWith;

        protected Collision2D LastCollision { get; private set; }

        private void OnCollision2D(Collision2D collision) 
        {
            if ((_onCollisionWith.value & (1 << collision.gameObject.layer)) != 0) 
            {
                LastCollision = collision;
                Execute();
            }
        }
    }
}