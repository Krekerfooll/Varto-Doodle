using System;
using UnityEngine;

namespace Alokhin.Stanislav.Utils
{
    public class ColliderExtender : MonoBehaviour
    {
        public Action<Collision2D> OnCollisionEnter;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEnter?.Invoke(collision);
        }
    }
}

