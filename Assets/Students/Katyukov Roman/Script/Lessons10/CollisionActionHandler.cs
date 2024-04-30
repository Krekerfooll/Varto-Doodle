using UnityEngine;

public class ColliderAction : Varto_ActionBase
{
    [SerializeField] private Collider2D _targetCollider; // Коллайдер игрока
    [SerializeField] private bool _activate; // Указывает, активировать ли или деактивировать коллайдер

    private Collider2D _platformCollider; // Коллайдер платформы, с которым мы будем работать

    private void Awake()
    {
        _platformCollider = GetComponent<Collider2D>();
        if (_platformCollider == null)
        {
            Debug.LogError("ColliderAction requires a Collider2D component on the same GameObject.");
        }
    }

    public override void Execute()
    {
        if (_targetCollider == null)
        {
            Debug.LogError("Target collider is not set for ColliderAction.");
            return;
        }

        // Проверяем, пересекается ли коллайдер игрока с коллайдером платформы
        if (_activate)
        {
            // Активировать триггер коллайдера
            if (!_platformCollider.isTrigger && _platformCollider.bounds.Intersects(_targetCollider.bounds))
            {
                _platformCollider.isTrigger = true;
                Debug.Log("Collider has been activated.");
            }
        }
        else
        {
            // Деактивировать триггер коллайдера
            if (_platformCollider.isTrigger && _platformCollider.bounds.Intersects(_targetCollider.bounds))
            {
                _platformCollider.isTrigger = false;
                Debug.Log("Collider has been deactivated.");
            }
        }
    }
}