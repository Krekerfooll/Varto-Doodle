using System;
using UnityEngine;

namespace Artur.Pashchenko.Utils
{
    public class CollisionExpander : MonoBehaviour
    {
        public Action<Collision2D> OnCollision;

        private void OnCollision2D(Collision2D collision)
        {
            OnCollision?.Invoke(collision);
        }
    }
}
