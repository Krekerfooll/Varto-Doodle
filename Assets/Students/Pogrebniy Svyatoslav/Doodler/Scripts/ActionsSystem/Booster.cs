
using UnityEngine;

public class Booster : CollisionEvent
{
    
    [SerializeField] private float _jumpBoost;
    
    public void BoostPlayer()
    {
       if (LastCollision.gameObject.transform.position.y > transform.position.y)
        LastCollision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _jumpBoost, ForceMode2D.Impulse);

    }

    protected override void ExecuteInternal()
    {
        BoostPlayer();
    }
}
