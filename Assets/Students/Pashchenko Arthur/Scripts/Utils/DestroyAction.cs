using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Artur.Pashchenko.Utils
{
    public class DestroyAction : ActionBase
    {
        [SerializeField] float _delay;
        public override void Execute()
        {
            Destroy(gameObject, _delay);
        }
    }
}