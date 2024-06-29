using UnityEngine;

namespace Ustich.Arthur.DoodleJump
{
    [CreateAssetMenu(fileName = "ActionDestroy", menuName = "CommandPattern/Actions/Destroy", order = 2)]
    public class ActionDestroySO : ActionBaseSO
    {
        [SerializeField] private ObjectToDestroyType _objectToDestroyType;
        [SerializeField] private float _delay;
        [SerializeField] private bool _ckeckDistance;
        [SerializeField] private float _explosionDistance;

        public override void Execute(object data = null)
        {
            switch (_objectToDestroyType)
            {
                case ObjectToDestroyType.TargetObject:
                    break;

                case ObjectToDestroyType.CollidedObject:
                    break;

                case ObjectToDestroyType.Self:
                    break;
            }
        }
    }
}