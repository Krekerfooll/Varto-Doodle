using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : OnCollisionEventsActionBase
{
    public enum DestructionType { Self, TargetObject, CollidedObject}

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
                Destroy(_objectToDestroy, _delay);
                break;

            case DestructionType.CollidedObject:
                Destroy(LastCollision.gameObject, _delay);
                break;
        }
    }

    protected override void ExecuteInternal()
    {
        Destroy();
    }
}
