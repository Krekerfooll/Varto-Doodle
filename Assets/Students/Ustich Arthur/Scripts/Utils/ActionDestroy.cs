using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    public class ActionDestroy : ActionBaseCollisionEvent
    {
        [SerializeField] private ActionBase _destroyAction;
        [SerializeField] private GameObject _objectToDestroy;
        [SerializeField] private ObjectToDestroyType _objectToDestroyType;
        [SerializeField] private float _delay;

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
    }
}
