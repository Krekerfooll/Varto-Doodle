using UnityEngine;

public class Destroyer : PlatformOnColision
{
    public enum DestructionType { Self, TargetObject, CollidedObject }

    [SerializeField] private DestructionType _destructionType;
    [SerializeField] private GameObject _objectToDestroy;
    [SerializeField] private float _delay;

    private void Start()
    {
        _delay = Mathf.Max(0, _delay);
    }

    protected override void ExecuteInternal()
    {
        Invoke("DestroyObject", _delay);
    }

    private void DestroyObject()
    {
        switch (_destructionType)
        {
            case DestructionType.Self:
                Destroy(gameObject);
                break;

            case DestructionType.TargetObject:
                if (_objectToDestroy != null)
                    Destroy(_objectToDestroy);
                break;

            case DestructionType.CollidedObject:
                if (LastCollision != null && LastCollision.gameObject != null)
                    Destroy(LastCollision.gameObject);
                break;
        }
    }
}
