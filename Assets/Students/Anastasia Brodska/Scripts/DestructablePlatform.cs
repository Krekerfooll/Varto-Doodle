using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Varto.Examples.Utils;

public class DestructablePlatform : MonoBehaviour
{

    [SerializeField] private ColliderExtender _collisionExtender;

    private void Awake()
    {
        _collisionExtender.OnCollisionEnter += OnCollide;
    }

    private void OnCollide(Collision2D collision)
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.red;
        if (collision.gameObject.layer == 0)
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
