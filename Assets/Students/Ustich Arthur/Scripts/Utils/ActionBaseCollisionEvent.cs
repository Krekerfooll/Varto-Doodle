using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public abstract class ActionBaseCollisionEvent : ActionBase
    {
        [SerializeField] private string[] _tags;
        protected Collider2D LastCollision { get; private set; }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (CheckTags(collision.gameObject.tag))
            {
                LastCollision = collision.gameObject.GetComponent<Collider2D>();
                Execute();
            } 
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (CheckTags(collision.gameObject.tag))
            {
                LastCollision = collision;
                Execute();
            }
        }

        private bool CheckTags(string _tag)
        {
            foreach (string tempTag in _tags)
            {
                if(_tag == tempTag)
                    return true;
            }
            return false;
        }
    }
}