using Alokhin.Stanislav.Utils;
using UnityEngine;

namespace Alokhin.Stanislav.PlatformGenerator
{
    public class DropsPlatforms : OnCollisionEventsActionBase
    {
        public enum DestructionType { Self, TargetObject, CollidedObject }

        [SerializeField] private DestructionType _destructionType;
        [SerializeField] private GameObject _objectToDestroy;
        [SerializeField] private float _delay;

        public void Destroy()
        {
            switch (_destructionType)
            {
                case DestructionType.Self:
                    Destroy(gameObject, _delay);
                    break;

                case DestructionType.TargetObject:
                    if (_objectToDestroy != null)
                    {
                        Destroy(_objectToDestroy, _delay);
                    }
                    break;


                case DestructionType.CollidedObject:
                    if (LastCollision != null)
                    {
                        Destroy(LastCollision.gameObject, _delay);
                    }
                    break;
            }
        }

        protected override void ExecuteInternal()
        {
            Destroy();
        }
    }
}

