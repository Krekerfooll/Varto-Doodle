using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderExtender : MonoBehaviour
{
    public Action<Collision2D> OnCollisionEnter;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollisionEnter?.Invoke(collision);
    }
}
