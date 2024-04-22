using UnityEditor.UIElements;
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
            if (CheckTags( collision.gameObject.tag))
            {
                LastCollision = collision;
                Execute();
            }
        }

        private bool CheckTags(string _tag)
        {
            bool _isCoincides;
            foreach (string tempTag in _tags)
            {
                _isCoincides = _tag == tempTag ? true : false;
                if (_isCoincides)
                    return _isCoincides;
            }
            return _isCoincides = false;
        }
    }
}
