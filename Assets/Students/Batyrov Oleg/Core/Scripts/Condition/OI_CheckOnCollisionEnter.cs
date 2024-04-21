using System.Collections.Generic;
using UnityEngine;

namespace OIMOD.Core.Component
{
    public class OI_CheckOnCollisionEnter : MonoBehaviour
    {
        [SerializeField] public GameObject _targetObject;
        [SerializeField] private List<OI_ActionBase> _onTriggerActions;
        [SerializeField] private float delay;

        private void OnCollisionEnter2D(Collision2D target)
        {
            if (_targetObject == null) return;

            if ((target.transform.tag == "Player") && (_targetObject.GetComponent<Rigidbody2D>().velocity.y <= 0))
            {
                foreach (var action in _onTriggerActions)
                {
                    action.Invoke("Execute",delay);
                }
            }
        }
    }
}
