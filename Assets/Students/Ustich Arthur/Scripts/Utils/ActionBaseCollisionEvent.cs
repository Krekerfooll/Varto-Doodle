using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public abstract class ActionBaseCollisionEvent : ActionBase
    {
        protected Collider2D LastCollision { get; private set; }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Block")
            {
                //LastCollision = collision;
                Execute();
            } 
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Block")
            {
                LastCollision = collision;
                Execute();
            }
        }
    }
}
