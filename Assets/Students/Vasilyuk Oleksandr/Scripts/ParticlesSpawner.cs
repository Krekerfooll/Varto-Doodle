using UnityEngine;

public class ParticlesSpawner : OnCollisionEventsActionBase
{
    [SerializeField] private LayerMask _playerLayerMask;
    [SerializeField] private ParticleSystem _particleSystem;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ((_playerLayerMask.value & (1 << collision.gameObject.layer)) != 0)
        {
            Execute();
        }
    }

    protected override void ExecuteInternal()
    {
            _particleSystem.Play();
    }
}
