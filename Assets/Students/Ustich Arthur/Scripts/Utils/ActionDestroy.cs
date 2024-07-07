using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class ActionDestroy : ActionBaseCollisionEvent
    {
        [SerializeField] private ActionBase _destroyAction;
        [SerializeField] private GameObject _objectToDestroy;
        [SerializeField] private ObjectToDestroyType _objectToDestroyType;
        [SerializeField] private float _delay;
        [SerializeField] private float _explosionDistance;
        public bool _CheckDistance;

        private float _minDelay = 0f;
        private float _maxDelay = 5.0f;

        public GameObject _ObjectToDestroy 
        { 
            get { return _objectToDestroy; } 
            set 
            { 
                if(_objectToDestroy == null)
                    _objectToDestroy = value;
            } 
        }
        public ObjectToDestroyType _ObjectToDestroyType { get { return _objectToDestroyType; } set { _objectToDestroyType = value; } }

        public float _Delay 
        { 
            get 
            { 
                return _delay;
            }
            set
            {
                if (value >= _minDelay && value <= _maxDelay)
                    _delay = value;
            } 
        }
        
        public float _ExplosionDistance 
        { 
            get 
            { 
                return _explosionDistance;
            } 
            set 
            {
                if(value >= 0)
                    _explosionDistance = value; 
            } 
        }



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
                    if (_CheckDistance)
                    {
                        Debug.Log("CHECK");
                        StartCoroutine(DestroyAtRangeWithDelay());
                    }  
                    if(!_CheckDistance)
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
