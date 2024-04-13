using System;
using UnityEngine;

namespace Varto.ScriptsVarto
{
    public class Varto_ColliderExtender : MonoBehaviour
    {
        public Action<Collision2D> OnCollisionEnter;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEnter?.Invoke(collision);
        }
    }
}
