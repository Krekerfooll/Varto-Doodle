using System.Collections;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class ActionDestroy : ActionBaseCollisionEvent
    {
        [SerializeField] private ActionBase _destroyAction;
        [SerializeField] private GameObject _objectToDestroy;
        [SerializeField] private ObjectToDestroyType _objectToDestroyType;
        [SerializeField] private float _delay;
        [SerializeField] private bool _checkDistance;
        [SerializeField] private float _explosionDistance;

        public override void ExecuteInternal()
        {
            ExecuteDestroy();
        }

        public void ExecuteDestroy()
        {
            switch (_objectToDestroyType)
            {
                case ObjectToDestroyType.CollidedObject:
                    Debug.Log("Colleded object");
                    _objectToDestroy = LastCollision.gameObject;
                    if (_checkDistance)
                    {
                        Debug.Log("CHECK");
                        StartCoroutine(DestroyAtRangeWithDelay());
                    }  
                    if(!_checkDistance)
                        Destroy(_objectToDestroy, _delay);
                    break;
                case ObjectToDestroyType.Self:
                    Destroy(gameObject, _delay);
                    break;
                case ObjectToDestroyType.TargetObject:
                    Destroy(_objectToDestroy, _delay);
                    break;
            }
        }

        IEnumerator DestroyAtRangeWithDelay()
        {
            yield return new WaitForSeconds(_delay);
            float distance = Vector3.Distance(_objectToDestroy.transform.position, transform.position);
            Debug.Log("Distance: " + distance);
            if (distance <= _explosionDistance)
            {
                Destroy(_objectToDestroy);
            }
            else
            {
                Debug.Log("Object is out of range and will not be destroyed.");
            }
        }
    }
}
