using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private Transform _deadLine;
    [SerializeField] private GameObject gameOverPanel;
    private void FixedUpdate()
    {
        if (transform.position.y < _deadLine.position.y)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
        if (gameOverPanel)
            gameOverPanel.SetActive(true);
    }
}
