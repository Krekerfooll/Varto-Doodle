using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    [SerializeField] protected Transform _target; // Цель, которую отслеживает платформа, например игрок.
    [SerializeField] protected GameObject _collider; // Коллайдер платформы, активация и деактивация которого управляется классом.

    [Space]
    [SerializeField] protected List<Varto_ActionBase> _executeOnCollisionActivated; // Список действий при активации коллайдера.
    [SerializeField] protected List<Varto_ActionBase> _executeOnCollisionDeactivated; // Список действий при деактивации коллайдера.

    protected bool _isInitiated = false; // Флаг, указывающий на инициализацию платформы.
    protected bool _isActivatedOnce = false; // Флаг, указывающий на однократную активацию платформы.

    // Метод для инициализации платформы
    public void InitPlatform(Transform target)
    {
        _target = target;
        _isInitiated = true;
    }

    void Update()
    {
        if (_isInitiated)
        {
            UpdatePlatformState();
        }
    }

    protected virtual void UpdatePlatformState()
    {
        if (_isActivatedOnce && !_collider.activeSelf)
        {
            return; // Прекращаем обновление, если платформа не должна повторно активироваться
        }

        // Проверяем позицию цели относительно платформы
        if (_target.position.y > transform.position.y)
        {
            ActivateCollider();
        }
        else if (_target.position.y < transform.position.y)
        {
            DeactivateCollider();
        }
    }

    protected void ActivateCollider()
    {
        if (!_collider.activeSelf)
        {
            _collider.SetActive(true);
            _isActivatedOnce = true;
            ExecuteActions(_executeOnCollisionActivated);
        }
    }

    protected void DeactivateCollider()
    {
        if (_collider.activeSelf)
        {
            _collider.SetActive(false);
            ExecuteActions(_executeOnCollisionDeactivated);
        }
    }

    // Метод для выполнения списка действий
    protected void ExecuteActions(List<Varto_ActionBase> actions)
    {
        foreach (var action in actions)
        {
            action.Execute();
        }
    }
}

public abstract class Varto_ActionBase : MonoBehaviour
{
    public abstract void Execute();
}