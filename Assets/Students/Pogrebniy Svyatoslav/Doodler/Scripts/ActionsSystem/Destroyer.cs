using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : CollisionEvent
{
    public enum DestructionType { Self, TargetObject, CollidedObject }

    [SerializeField] private DestructionType _destructionType;
    [SerializeField] private GameObject _objectToDestroy;
    [SerializeField] private int _delay;

    public void Destroy()
    {
        if (LastCollision.gameObject.transform.position.y > transform.position.y)
        {
            switch (_destructionType)
            {
                case DestructionType.Self:
                    Delay();
                    //gameObject.SetActive(false);
                    //Destroy(gameObject, _delay);
                    break;

                case DestructionType.TargetObject:
                    Destroy(_objectToDestroy, _delay);
                    break;

                case DestructionType.CollidedObject:
                    Destroy(LastCollision.gameObject, _delay);
                    break;
            }
        }
    }

    protected override void ExecuteInternal()
    {
        Destroy();
    }

    void Delay()
    
       {
           StartCoroutine(RemoveAfterSeconds(_delay, gameObject));
       }
    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(_delay);
        obj.SetActive(false);
    }
    
}
