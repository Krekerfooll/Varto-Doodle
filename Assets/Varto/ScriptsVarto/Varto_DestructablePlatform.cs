using UnityEngine;
using Varto.ScriptsVarto.Platforms;

namespace Varto.ScriptsVarto
{
    public class Varto_DestructablePlatform : Varto_Platform
    {
        [SerializeField] private Varto_ColliderExtender _collisionExtender;

        private void Awake()
        {
            _collisionExtender.OnCollisionEnter += OnCollide;
        }

        private void OnCollide(Collision2D collision)
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.red;
            if (collision.gameObject.layer == 0)
            {
                Destroy(gameObject, 0.5f);
            }
        }
    }
}