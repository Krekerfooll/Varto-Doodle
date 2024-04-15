using UnityEngine;

public abstract class PlatformOnColision : PlatformBase
{
    [SerializeField] private LayerMask _onCollisionEnterWith;

    protected Collision2D LastCollision { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_executeOnlyOnes && _isExecutedOnes)
            return;

        if ((_onCollisionEnterWith.value & (1 << collision.gameObject.layer)) != 0)
        {
            LastCollision = collision;
            ExecuteInternal();
        }
    }
}
